package dk.groupfive.ModeratorServer.model;

import dk.groupfive.ModeratorServer.local.Cache;
import dk.groupfive.ModeratorServer.model.objects.*;
import dk.groupfive.ModeratorServer.remote.Client;
import dk.groupfive.ModeratorServer.remote.Server;

import java.io.IOException;
import java.util.List;

public class ModeratorModel implements Model {
    private static volatile ModeratorModel instance;
    private final static Object lock = new Object();

    private final Cache cache;
    private final Server server;

    private ModeratorModel() throws IOException {
        cache = new Cache();
        server = new Client();
        loader();
    }

    private void loader() {
        //loads data from t3 every 10 minutes
        new Thread(() -> {
            try {
                cache.loadPlaceReports(server.getPlaceReports());
            } catch (IOException e) {
                e.printStackTrace();
            }

            try {
                Thread.sleep(10 * 60 * 1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }).start();
    }

    public static Model getInstance() {
        if (instance == null) {
            synchronized (lock) {
                if (instance == null) {
                    try {
                        instance = new ModeratorModel();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
        return instance;
    }

    @Override
    public List<Report<ReviewItem>> getReviewReports() {
        return cache.getReviewReports();
    }

    @Override
    public List<Report<Place>> getPlaceReports() {
        return cache.getPlaceReports();
    }

    @Override
    public List<Report<User>> getUserReports() {
        return cache.getUserReports();
    }

    @Override
    public void resolvePlace(long placeId, String action) {
        switch (action) {
            case "remove":
                removePlace(placeId);
                break;
            default:
                System.out.println("Not implemented");
        }
    }

    @Override
    public void resolveReview(long reviewId, String action) {
        switch (action) {
            case "remove":
                removeReview(reviewId);
                break;
            default:
                System.out.println("Not implemented");
        }
    }

    @Override
    public void resolveUser(long userId, String action) {
        switch (action) {
            case "ban":
                banUser(userId);
                break;
            case "unban":
                unbanUser(userId);
                break;
            case "flag":
                flagUser(userId);
                break;
            default:
                System.out.println("Not implemented");
        }
    }

    @Override
    public List<User> getBannedUsers() {
        return cache.getBannedUsers();
    }

    public void dismissPlaceReport(long reportId) {
        server.dismissPlaceReport(reportId);
        new Thread(() -> {
            cache.getPlaceReports().stream().filter(report -> report.getReportId() == reportId).forEach(report -> report.setResolved(true));
        }).start();
    }

    public void dismissReviewReport(long reportId) {
        server.dismissReviewReport(reportId);
        new Thread(() -> {
            cache.getReviewReports().stream().filter(report -> report.getReportId() == reportId).forEach(report -> report.setResolved(true));
        }).start();
    }

    public void dismissUserReport(long reportId) {
        server.dismissUserReport(reportId);
        new Thread(() -> {
            cache.getUserReports().stream().filter(report -> report.getReportId() == reportId).forEach(report -> report.setResolved(true));
        }).start();
    }

    //todo also resolve report on t3
    private void removePlace(long placeId) {
        //gets the placeID of the first report that contains the reported place based on the id of the report (ask paul if unclear)
        //long placeId = cache.getPlaceReports().stream().filter(report -> report.getReportId() == reportId).findFirst().get().getReportedItem().getId();
        server.removePlace(placeId);

        //marks all reports regarding that place as solved, as there may be multiple reports for the same item
        cache.getPlaceReports().stream().filter(report -> report.getReportedItem().getId() == placeId).forEach(report -> report.setResolved(true));
    }

    private void removeReview(long reviewId) {
        //long reviewId = cache.getReviewReports().stream().filter(report -> report.getReportId() == reportId).findFirst().get().getReportedItem().getId();
        server.removeReview(reviewId);
        cache.getReviewReports().stream().filter(report -> report.getReportedItem().getId() == reviewId).forEach(report -> report.setResolved(true));
    }

    private void banUser(long userId) {
        //long userId = cache.getUserReports().stream().filter(report -> report.getReportId() == reportId).findFirst().get().getReportedItem().getId();
        server.banUser(userId);
        try {
            cache.addBannedUser(server.getUserById(userId));
        } catch (IOException e) {
            e.printStackTrace();
        }
        cache.getUserReports().stream().filter(report -> report.getReportedItem().getId() == userId).forEach(report -> report.setResolved(true));
    }

    //maybe this should be changed to just userID, since a report to unban a user cannot be made
    private void unbanUser(long userId) {

    }

    private void flagUser(long userId) {
        //moderator can flag a user = creates report for user with title "Flagged by {x}" where x is the id of the moderator user
        //to be implemented on normal client side
    }

    //todo restores, leave for end (client would have section for solved reports
}
