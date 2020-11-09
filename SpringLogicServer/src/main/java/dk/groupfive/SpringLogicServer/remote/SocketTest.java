package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.io.IOException;
import java.util.List;

public class SocketTest {
    public static void main(String[] args) throws IOException {
        try {
            Client client = new Client();
            client.addPlace(new Place(1,2,"Great Title", "Great Description"));
            List<Place> places = client.getAllPlaces();
            System.out.println(places);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }



    }
}
