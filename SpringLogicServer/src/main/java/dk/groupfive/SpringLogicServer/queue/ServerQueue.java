package dk.groupfive.SpringLogicServer.queue;

import com.google.gson.Gson;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.MessageProperties;
import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.ServerModel;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Report;
import dk.groupfive.SpringLogicServer.model.objects.Review;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;
import dk.groupfive.SpringLogicServer.model.objects.User;
import dk.groupfive.SpringLogicServer.model.tasks.PlaceTask;
import dk.groupfive.SpringLogicServer.model.tasks.ReviewTask;

import java.io.IOException;
import java.util.List;
import java.util.concurrent.TimeoutException;

public class ServerQueue implements Model {
    private static volatile ServerQueue instance;
    private final static Object lock = new Object();

    private final static String PLACE_QUEUE = "places";
    private final static String REPORT_QUEUE = "reports";
    private final static String REVIEW_QUEUE = "reviews";
    private ConnectionFactory factory;
    private Channel channel;
    private Gson gson;

    private ServerQueue() {
        gson = new Gson();
        factory = new ConnectionFactory();
        factory.setHost("localhost");
        try {
            /**
             * @exception if you get error here install erlang and rabbitmq server
             * @url https://www.erlang.org/downloads
             * @url https://www.rabbitmq.com/install-windows.html#installer
             */
            Connection connection = factory.newConnection();
            channel = connection.createChannel();
            channel.queueDeclare(PLACE_QUEUE, true, false, false, null);
            channel.queueDeclare(REPORT_QUEUE, true, false, false, null);
            channel.queueDeclare(REVIEW_QUEUE, true, false, false, null);
            channel.basicQos(1);
        } catch (TimeoutException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static ServerQueue getInstance() {
        if(instance == null) {
            synchronized (lock) {
                if(instance == null) {
                    instance = new ServerQueue();
                }
            }
        }
        return instance;
    }

    @Override
    public List<Place> getAllPlaces() {
        return ServerModel.getInstance().getAllPlaces();
    }

    @Override
    public Place getPlaceByID(long id) {
        return ServerModel.getInstance().getPlaceByID(id);
    }

    @Override
    public void addPlace(Place place) {
        PlaceTask task = new PlaceTask("addPlace", place);
        try {
            channel.basicPublish("", PLACE_QUEUE, MessageProperties.PERSISTENT_TEXT_PLAIN, gson.toJson(task).getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void updatePlace(Place place) {
        PlaceTask task = new PlaceTask("updatePlace", place);
        try {
            channel.basicPublish("", PLACE_QUEUE, MessageProperties.PERSISTENT_TEXT_PLAIN, gson.toJson(task).getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void deletePlace(long id) {
        PlaceTask task = new PlaceTask("deletePlace", id);
        try {
            channel.basicPublish("", PLACE_QUEUE, MessageProperties.PERSISTENT_TEXT_PLAIN, gson.toJson(task).getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void addPlaceReview(long id, Review reviewItem) {
        ReviewTask task = new ReviewTask("addPlaceReview", id, reviewItem);
        try {
            channel.basicPublish("", REVIEW_QUEUE, MessageProperties.PERSISTENT_TEXT_PLAIN, gson.toJson(task).getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void addSavedPlace(long userId, long placeId) {
        ServerModel.getInstance().addSavedPlace(userId,placeId);
    }

    @Override
    public void removeSavedPlace(long userId, long placeId) {
        ServerModel.getInstance().removeSavedPlace(userId,placeId);
    }

    @Override
    public void addReportPlace(Report<Place> report) {
        try {
            channel.basicPublish("", REPORT_QUEUE, MessageProperties.PERSISTENT_TEXT_PLAIN, gson.toJson(report).getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void addReportUser(Report<User> report) {
        try {
            channel.basicPublish("", REPORT_QUEUE, MessageProperties.PERSISTENT_TEXT_PLAIN, gson.toJson(report).getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void addReportReview(Report<Review> report) {
        try {
            channel.basicPublish("", REPORT_QUEUE, MessageProperties.PERSISTENT_TEXT_PLAIN, gson.toJson(report).getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
