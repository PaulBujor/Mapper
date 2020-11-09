package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.io.*;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class Client implements Server {
    final String HOST = "localhost";
    final int PORT = 6969;
    private Socket socket;
    private PrintWriter out;
    private BufferedReader in;

    public Client() throws IOException {
        socket = new Socket("localhost", 6969);
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new PrintWriter(socket.getOutputStream(), true);
    }

    @Override
    public List<Place> getAllPlaces() {
        List<Place> places = new ArrayList<Place>();
        out.println();
    }

    @Override
    public Place getPlaceByID(long id) {
        return null;
    }

    //todo this should wait for a place with id from the server, then return it
    @Override
    public Place addPlace(Place place) {
        return null;
    }

    @Override
    public void updatePlace(Place place) {

    }

    @Override
    public void deletePlace(long id) {

    }
}
