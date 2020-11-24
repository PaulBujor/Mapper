package dk.groupfive.SpringLogicServer.remote;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.*;
import java.lang.reflect.Type;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class PlaceClient implements Server {
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

    @Override
    public List<Place> getAllPlaces() throws IOException {
        List<Place> places;
        out.println("getAllPlaces");
        String response = in.readLine();
        Type placeListType = new TypeToken<ArrayList<Place>>(){}.getType();
        places = gson.fromJson(response, placeListType);
        return places;
    }

    @Override
    public Place getPlaceByID(long id) {


        return null;
    }

    //todo this should wait for a place with id from the server, then return it
    @Override
    public Place addPlace(Place place) throws IOException {
        out.println("addPlace");
        String send = gson.toJson(place);
        out.println(send);
        String response = in.readLine();
        Place receivedPlace = gson.fromJson(response, Place.class);
        return receivedPlace;
    }

    @Override
    public void updatePlace(Place place) {
        out.println("updatePlace");
        String send = gson.toJson(place);
        out.println(send);
    }

    @Override
    public void deletePlace(long id) {
        out.println("deletePlace");
        out.println(id);
    }


}
