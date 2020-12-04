package dk.groupfive.SpringLogicServer.queue;

import com.google.gson.Gson;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.DeliverCallback;
import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.ReviewItem;
import dk.groupfive.SpringLogicServer.model.tasks.PlaceTask;
import dk.groupfive.SpringLogicServer.model.tasks.ReviewTask;

import java.io.IOException;
import java.util.concurrent.TimeoutException;

public class ReviewWorker {

    private static final String QUEUE_NAME = "reviews";
    private ConnectionFactory factory;
    private Channel channel;
    private Gson gson;
    private Model model;

    public ReviewWorker(Model model) {
        this.model = model;
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
                ReviewTask task = gson.fromJson(message, ReviewTask.class);
                try {
                    addPlaceReview(task.getId(), task.getReviewItem());
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


    public void addPlaceReview(long id, ReviewItem reviewItem)
    {
        model.addPlaceReview(id, reviewItem);
    }
}
