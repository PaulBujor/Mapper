package dk.groupfive.SpringLogicServer.model;

import dk.groupfive.SpringLogicServer.broadcast.Broadcaster;
import dk.groupfive.SpringLogicServer.local.Cache;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.tasks.PlaceTask;
import dk.groupfive.SpringLogicServer.queue.PlaceWorker;
import dk.groupfive.SpringLogicServer.remote.Server;
import dk.groupfive.SpringLogicServer.remote.Client;

import java.io.IOException;
import java.util.List;
import java.util.concurrent.ExecutorService;

public class ServerModel implements Model {
    private static volatile ServerModel instance;
    private final static Object lock = new Object();

    private final Cache cache;
    private final Server server;
    private final Broadcaster broadcaster;

    private PlaceWorker worker;

    private ServerModel() throws IOException {
        cache = new Cache();
        server = new Client();
        broadcaster = new Broadcaster();
        worker = new PlaceWorker(this);

        //we want this to be sync so data is loaded before anything else is added.
        try {
            cache.load(server.getAllPlaces());
        } catch (IOException e) {
            e.printStackTrace();
        }
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
}
