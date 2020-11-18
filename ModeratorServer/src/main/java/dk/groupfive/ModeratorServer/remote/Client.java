package dk.groupfive.ModeratorServer.remote;

import com.google.gson.Gson;
import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Review;
import dk.groupfive.ModeratorServer.model.objects.User;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class Client implements Server {
        final String HOST = "localhost";
        final int PORT = 6969;
        private Socket socket;
        private PrintWriter out;
        private BufferedReader in;
        private Gson gson;

    public Client() throws IOException {
        socket = new Socket(HOST, PORT);
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new PrintWriter(socket.getOutputStream(), true);
        gson = new Gson();
    }

    @Override
    public boolean authenticateUser(User user) throws Exception {
        out.println("authenticateUser");
        out.println(gson.toJson(user));
        try {
            return Boolean.parseBoolean(in.readLine());
        } catch (IOException e) {
            e.printStackTrace();
            throw new Exception("User not authorized");
        }
    }

    @Override
    public void removePlace(Place place) {
        out.println("deletePlace");
        out.println(place.getId());
    }

    @Override
    public void removeReview(Review review) {

    }

    @Override
    public User banUser(User user) {

        return user;
    }

    @Override
    public User unbanUser(User user) {

        return user;
    }
}
