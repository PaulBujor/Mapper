package dk.groupfive.SpringLogicServer.model;

import dk.groupfive.SpringLogicServer.broadcast.Broadcaster;
import dk.groupfive.SpringLogicServer.local.Cache;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Report;
import dk.groupfive.SpringLogicServer.model.objects.Review;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;
import dk.groupfive.SpringLogicServer.model.objects.User;
import dk.groupfive.SpringLogicServer.model.tasks.PlaceTask;
import dk.groupfive.SpringLogicServer.queue.PlaceWorker;
import dk.groupfive.SpringLogicServer.queue.ReportWorker;
import dk.groupfive.SpringLogicServer.queue.ReviewWorker;
import dk.groupfive.SpringLogicServer.remote.Router;
import dk.groupfive.SpringLogicServer.remote.Server;

import java.io.IOException;
import java.util.List;

public class ServerModel implements Model {
    private static volatile ServerModel instance;
    private final static Object lock = new Object();

    private final Cache cache;
    private final Server server;
    private final Broadcaster broadcaster;

    private PlaceWorker placeWorker;
    private ReportWorker reportWorker;
    private ReviewWorker reviewWorker;

    private ServerModel() throws IOException {
        cache = new Cache();
        server = new Router();
        broadcaster = new Broadcaster();
        placeWorker = new PlaceWorker(this);
        reportWorker = new ReportWorker(this);
        reviewWorker = new ReviewWorker(this);
        loader();
    }

    private void loader() {
        //loads data from t3 every 15 minutes
        new Thread(() -> {
            try {
                cache.load(server.getAllPlaces());
            } catch (IOException e) {
                e.printStackTrace();
            }

            try {
                Thread.sleep(15 * 60 * 1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }).start();
    }

    public static ServerModel getInstance() {
        if (instance == null) {
            synchronized (lock) {
                if (instance == null) {
                    try {
                        instance = new ServerModel();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
        return instance;
    }

    @Override
    public List<Place> getAllPlaces() {
        return cache.getAllPlaces();
    }

    @Override
    public Place getPlaceByID(long id) {
        return cache.getPlaceByID(id);
    }

    @Override
    public void addPlace(Place place) {
        try {
            place = server.addPlace(place);
        } catch (IOException e) {
            e.printStackTrace();
        }
        cache.addPlace(place);
        broadcaster.sendTask(new PlaceTask("addPlace", place));
    }

    @Override
    public void addPlaceReview(long id, Review reviewItem) {
        try {
            reviewItem = server.addPlaceReview(id, reviewItem);
        } catch (IOException e) {
            e.printStackTrace();
        }
        cache.addPlaceReview(id, reviewItem);
        broadcaster.sendTask(new PlaceTask("updatePlace", cache.getPlaceByID(id)));
    }

    @Override
    public void addSavedPlace(long userId, long placeId) {
        server.addSavedPlace(userId, placeId);
    }

    @Override
    public void removeSavedPlace(long userId, long placeId) {
        server.removeSavedPlace(userId, placeId);
    }

    @Override
    public void updatePlace(Place place) {
        server.updatePlace(place);
        cache.updatePlace(place);
    }

    @Override
    public void deletePlace(long id) {
        server.deletePlace(id);
        cache.deletePlace(id);
    }

    public void subscribe(String ip) {
        broadcaster.subscribe(ip);
    }


    @Override
    public void addReportPlace(Report<Place> report){
        try {
            server.addReportPlace(report);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void addReportUser(Report<User> report) {
        try {
            server.addReportUser(report);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void addReportReview(Report<Review> report) {
        try {
            server.addReportReview(report);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
