package dk.groupfive.SpringLogicServer.remote;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import dk.groupfive.SpringLogicServer.model.objects.*;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;

import java.io.*;
import java.lang.reflect.Type;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class PlaceClient {
    final String HOST = "localhost";
    final int PORT = 7000;
    private Socket socket;
    private PrintWriter out;
    private BufferedReader in;
    private Gson gson;

    public PlaceClient() throws IOException {
        socket = new Socket(HOST, PORT);
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new PrintWriter(socket.getOutputStream(), true);
        gson = new Gson();
    }

    public List<Place> getAllPlaces() throws IOException {
        List<Place> places;
        out.println("getAllPlaces");
        String response = in.readLine();
        System.out.println(response);

        Type placeListType = new TypeToken<ArrayList<Place>>(){}.getType();
        places = gson.fromJson(response, placeListType);
        System.out.println(places);
        System.out.println(gson.toJson(places));
        return places;
    }


    public Place getPlaceByID(long id) {


        return null;
    }

    //todo this should wait for a place with id from the server, then return it
    public Place addPlace(Place place) throws IOException {
        out.println("addPlace");
        String send = gson.toJson(place);
        out.println(send);
        String response = in.readLine();
        Place receivedPlace = gson.fromJson(response, Place.class);
        return receivedPlace;
    }

    public void updatePlace(Place place) {
        out.println("updatePlace");
        String send = gson.toJson(place);
        out.println(send);
    }

    public void deletePlace(long id) {
        out.println("deletePlace");
        out.println(id);
    }

    public Review addPlaceReview(long id, Review reviewItem) throws IOException {
        out.println("addPlaceReview");
        String sendPlaceId = gson.toJson(id);
        out.println(sendPlaceId);
        String sendReviewItem = gson.toJson(reviewItem);
        out.println(sendReviewItem);
        String response = in.readLine();
        Review receivedReviewItem = gson.fromJson(response, Review.class);
        return receivedReviewItem;
    }

    public void addSavedPlace(long userId, long placeId)
    {
        out.println("addSavedPlace");
        String sendUserId = gson.toJson(userId);
        out.println(sendUserId);
        String sendPlaceId = gson.toJson(placeId);
        out.println(sendPlaceId);
        System.out.println("Sending userid and placeid to t3...");
    }

    public void removeSavedPlace(long userId, long placeId)
    {
        out.println("removeSavedPlace");
        out.println(userId);
        out.println(placeId);
        System.out.println("Sending userid and placeid to t3...");
    }

}
