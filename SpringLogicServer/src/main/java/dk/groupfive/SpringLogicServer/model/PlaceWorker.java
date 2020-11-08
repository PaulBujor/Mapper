package dk.groupfive.SpringLogicServer.model;

import com.google.gson.Gson;
import com.rabbitmq.client.*;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.tasks.PlaceTask;

import java.io.IOException;
import java.util.concurrent.TimeoutException;

public class PlaceWorker {
    private static final String QUEUE_NAME = "places";
    private ConnectionFactory factory;
    private Channel channel;
    private Gson gson;
    private Model model;

    public PlaceWorker() {
        gson = new Gson();
        factory = new ConnectionFactory();
        factory.setHost("localhost");
        try {
            Connection connection = factory.newConnection();
            channel = connection.createChannel();
            channel.queueDeclare(QUEUE_NAME, true, false, false, null);
            channel.basicQos(1);

            DeliverCallback deliverCallback = (consumerTag, delivery) -> {
                String message = new String(delivery.getBody(), "UTF-8");
                PlaceTask task = gson.fromJson(message, PlaceTask.class);
                try {
                    processTask(task);
                } catch (Exception e) {
                    e.printStackTrace();
                } finally {
                    channel.basicAck(delivery.getEnvelope().getDeliveryTag(), false);
                }
            };
            channel.basicConsume(QUEUE_NAME, false, deliverCallback, consumerTag -> {
            });

        } catch (TimeoutException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void processTask(PlaceTask task) throws Exception {
        switch (task.getTaskName()){
            case "addPlace":
                addPlace(task.getPlace());
                break;
            case "updatePlace":
                updatePlace(task.getPlace());
                break;
            case "deletePlace":
                deletePlace(task.getPlaceID());
                break;
            default:
                throw new Exception("Task undefined: " + task.getTaskName());
        }
    }

    public void addPlace(Place place) {
        model.addPlace(place);
    }

    public void updatePlace(Place place) {
        model.updatePlace(place);
    }

    public void deletePlace(long id) {
        model.deletePlace(id);
    }
}
