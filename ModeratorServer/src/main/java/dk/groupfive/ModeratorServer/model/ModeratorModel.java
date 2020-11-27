package dk.groupfive.ModeratorServer.model;

import dk.groupfive.ModeratorServer.local.Cache;
import dk.groupfive.ModeratorServer.model.objects.*;
import dk.groupfive.ModeratorServer.remote.Client;
import dk.groupfive.ModeratorServer.remote.Server;

import java.io.IOException;
import java.util.List;

public class ModeratorModel implements Model{
    private static volatile ModeratorModel instance;
    private final static Object lock = new Object();

    private final Cache cache;
    private final Server server;

    private ModeratorModel() throws IOException {
        cache = new Cache();
        server = new Client();
        //cache.loadReports(null);//todo load with reports from the server -- put in new thread that reloads every x amount of time
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
    public void resolvePlace(long reportId, String action) {
        switch (action) {
            case "remove":
                removePlace(reportId);
                break;
            default:
                System.out.println("Not implemented");
        }
    }

    @Override
    public void resolveReview(long reportId, String action) {
        switch (action) {
            case "remove":
                removeReview(reportId);
                break;
            default:
                System.out.println("Not implemented");
        }
    }

    @Override
    public void resolveUser(long reportId, String action) {
        switch (action) {
            case "ban":
                banUser(reportId);
                break;
            case "unban":
                unbanUser(reportId);
                break;
            default:
                System.out.println("Not implemented");
        }
    }

    //todo also resolve report on t3
    private void removePlace(long reportId) {
        //gets the placeID of the first report that contains the reported place based on the id of the report (ask paul if unclear)
        long placeId = cache.getPlaceReports().stream().filter(report -> report.getReportId() == reportId).findFirst().get().getReportedItem().getId();

        server.removePlace(placeId);

        //marks all reports regarding that place as solved, as there may be multiple reports for the same item
        cache.getPlaceReports().stream().filter(report -> report.getReportedItem().getId() == placeId).forEach(report -> report.setResolved(true));
    }

    private void removeReview(long reportId) {
        long reviewId = cache.getReviewReports().stream().filter(report -> report.getReportId() == reportId).findFirst().get().getReportedItem().getId();
        server.removeReview(reviewId);
        cache.getReviewReports().stream().filter(report -> report.getReportedItem().getId() == reviewId).forEach(report -> report.setResolved(true));
    }

    private void banUser(long reportId) {
        long userId = cache.getUserReports().stream().filter(report -> report.getReportId() == reportId).findFirst().get().getReportedItem().getId();
        server.banUser(userId);
        cache.getUserReports().stream().filter(report -> report.getReportedItem().getId() == userId).forEach(report -> report.setResolved(true));
    }

    //maybe this should be changed to just userID, since a report to unban a user cannot be made
    private void unbanUser(long reportId) {

    }

    //todo restores, leave for end (client would have section for solved reports
}
