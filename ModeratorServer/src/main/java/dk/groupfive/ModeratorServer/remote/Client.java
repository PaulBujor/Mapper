package dk.groupfive.ModeratorServer.remote;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Report;
import dk.groupfive.ModeratorServer.model.objects.Review;
import dk.groupfive.ModeratorServer.model.objects.User;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.lang.reflect.Type;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

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
    public synchronized List<Report<Place>> getPlaceReports() throws IOException {
        out.println("getPlaceReports");
        Type placeReportsType = new TypeToken<List<Report<Place>>>() {
        }.getType();
        return gson.fromJson(in.readLine(), placeReportsType);
    }

    @Override
    public synchronized List<Report<User>> getUserReports() throws IOException {
        out.println("getUserReports");
        Type userReportsType = new TypeToken<List<Report<User>>>() {
        }.getType();
        return gson.fromJson(in.readLine(), userReportsType);
    }

    @Override
    public synchronized List<Report<Review>> getReviewReports() throws IOException {
        out.println("getReviewReports");
        Type reviewReportsType = new TypeToken<List<Report<Review>>>() {
        }.getType();
        return gson.fromJson(in.readLine(), reviewReportsType);
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

    @Override
    public synchronized void dismissPlaceReport(long reportId) {
        out.println("dismissPlaceReport");
        out.println(reportId);
    }

    @Override
    public synchronized void dismissReviewReport(long reportId) {
        out.println("dismissReviewReport");
        out.println(reportId);
    }

    @Override
    public synchronized void dismissUserReport(long reportId) {
        out.println("dismissUserReport");
        out.println(reportId);
    }

    @Override
    public synchronized User getUserById(long userId) throws IOException {
        out.println("getUserById");
        out.println(userId);
        return gson.fromJson(in.readLine(), User.class);
    }

    @Override
    public List<User> getBannedUsers() throws IOException {
        out.println("getBannedUsers");
        Type bannedUsersType = new TypeToken<List<User>>() {
        }.getType();
        return gson.fromJson(in.readLine(), bannedUsersType);
    }
}
