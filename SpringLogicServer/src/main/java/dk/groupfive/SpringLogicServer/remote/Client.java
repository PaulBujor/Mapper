package dk.groupfive.SpringLogicServer.remote;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.io.*;
import java.lang.reflect.Type;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class Client implements Server {
    final String HOST = "localhost";
    final int PORT = 6969;
    private Socket socket;
    private PrintWriter out;
    private BufferedReader in;
    private Gson gson;

    public Client() throws IOException {
        socket = new Socket("localhost", 6969);
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new PrintWriter(socket.getOutputStream(), true);
        gson = new Gson();
    }

    @Override
    public List<Place> getAllPlaces() throws IOException {
        List<Place> places;
        out.println("getAllPlaces");
        byte[] response = in.readLine().getBytes();
        String stringResponse = new String(response);
        Type placeListType = new TypeToken<ArrayList<Place>>(){}.getType();
        System.out.println(stringResponse);
        /*places = gson.fromJson(stringResponse, placeListType);*/
        return null;
    }

    @Override
    public Place getPlaceByID(long id) {


        return null;
    }

    //todo this should wait for a place with id from the server, then return it
    @Override
    public Place addPlace(Place place) {
        out.println("addPlace");

        return null;

    }

    @Override
    public void updatePlace(Place place) {

    }

    @Override
    public void deletePlace(long id) {

    }
}
