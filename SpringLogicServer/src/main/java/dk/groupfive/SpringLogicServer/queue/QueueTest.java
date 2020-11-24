package dk.groupfive.SpringLogicServer.queue;

import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.io.IOException;
import java.util.List;

public class QueueTest {
    public static void main(String[] args) throws IOException {
        try {
            //Client client = new Client();
            ServerQueue queue = ServerQueue.getInstance();
            queue.addPlace(new Place(1,2,"Great Title", "Great Description"));
            List<Place> places = queue.getAllPlaces();
            System.out.println(places);
            //System.out.println(client.getAllPlaces());
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
