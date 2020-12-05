package dk.groupfive.SpringLogicServer.queue;

import com.google.gson.Gson;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import com.rabbitmq.client.DeliverCallback;
import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Report;
import dk.groupfive.SpringLogicServer.model.objects.Review;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;
import java.util.concurrent.TimeoutException;

public class ReportWorker {

    private static final String QUEUE_NAME = "reports";
    private ConnectionFactory factory;
    private Channel channel;
    private Gson gson;
    private Model model;

    public ReportWorker(Model model) {
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
                System.out.println(message);
                Report<?> task = gson.fromJson(message, Report.class);
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

    public void processTask(Report<?> task) throws Exception {
        switch (task.getReportedClass())
        {
            case "Place" :
                addReportPlace((Report<Place>) task);
                break;
            case "User" :
                addReportUser((Report<User>) task);
                break;
            case "ReviewItem" :
                addReportReview((Report<Review>) task);
                break;
            default:
                System.out.println(task.getReportedClass());
        }
    }

    public void addReportPlace(Report<Place> report)
    {
        model.addReportPlace(report);
    }

    public void addReportUser(Report<User> report)
    {
        model.addReportUser(report);
    }

    public void addReportReview(Report<Review> report)
    {
        model.addReportReview(report);
    }


}
