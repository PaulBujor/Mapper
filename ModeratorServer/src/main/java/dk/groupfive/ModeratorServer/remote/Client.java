package dk.groupfive.ModeratorServer.remote;

import com.google.gson.Gson;
import dk.groupfive.ModeratorServer.model.objects.User;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class Client implements Server {
        final String HOST = "localhost";
        final int PORT = 7010; //moderator port
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
    public synchronized boolean authorizeUser(User user) throws Exception {
        out.println("authorizeUser");
        out.println(gson.toJson(user));
        try {
            return Boolean.parseBoolean(in.readLine());
        } catch (IOException e) {
            e.printStackTrace();
            throw new Exception("User not authorized");
        }
    }

    @Override
    public synchronized void removePlace(long placeId) {
        out.println("removePlace");
        out.println(placeId);
    }

    @Override
    public synchronized void removeReview(long reviewId) {
        out.println("removeReview");
        out.println(reviewId);
    }

    @Override
    public synchronized void banUser(long userId) {
        out.println("banUser");
        out.println(userId);
    }

    @Override
    public synchronized void unbanUser(long userId) {
        out.println("unbanUser");
        out.println(userId);
    }
}
