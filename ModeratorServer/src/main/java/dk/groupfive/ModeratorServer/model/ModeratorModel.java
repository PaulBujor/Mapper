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
        cache.loadReports(null);//todo load with reports from the server -- put in new thread that reloads every x amount of time
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
    public List<Report> getReports() {
        return cache.getReports();
    }

    @Override
    public Report getReport(long id) {
        return cache.getReport(id);
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

    private void removePlace(long reportId) {
        Report report = cache.getReport(reportId);
        Place reportedPlace = (Place) report.getReportedItem();
        report.setResolved(true);
        server.removePlace(reportedPlace.getId());
    }

    private void removeReview(long reportId) {
        Report report = cache.getReport(reportId);
        ReviewItem reportedReview = (ReviewItem) report.getReportedItem();
        report.setResolved(true);
        server.removeReview(reportedReview.getId());
    }

    private void banUser(long reportId) {
        Report report = cache.getReport(reportId);
        User user = (User) report.getReportedItem();
        report.setResolved(true);
        server.banUser(user.getId());
    }

    private void unbanUser(long reportId) {
        //todo might have to change this
//        Report report = cache.getReport(reportId);
//        User user = (User) report.getReportedItem();
//        report.setResolved(true);
//        server.unbanUser(user.getId());
    }
}
