package dk.groupfive.ModeratorServer.local;

import dk.groupfive.ModeratorServer.model.objects.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Cache {
    private Map<Long, Report<Place>> placeReports;
    private Map<Long, Report<ReviewItem>> reviewReports;
    private Map<Long, Report<User>> userReports;
    private Map<Long, User> bannedUsers;

    public Cache() {
        placeReports = new HashMap<>();
        reviewReports = new HashMap<>();
        userReports = new HashMap<>();
    }

    public void loadPlaceReports(List<Report<Place>> reports) {
        for (Report<Place> report : reports) {
            placeReports.put(report.getReportId(), report);
        }
    }

    public void loadReviewReports(List<Report<ReviewItem>> reports) {
        for (Report<ReviewItem> report : reports) {
            reviewReports.put(report.getReportId(), report);
        }
    }

    public void loadUserReports(List<Report<User>> reports) {
        for (Report<User> report : reports) {
            userReports.put(report.getReportId(), report);
        }
    }

    public void laodBanneeUsers(List<User> users) {
        for (User user : users) {
            bannedUsers.put(user.getId(), user);
        }
    }

    //public Report getReport(long id) {
//        return reports.get(id);
//    }

    public List<Report<ReviewItem>> getReviewReports() {
        return (ArrayList<Report<ReviewItem>>) reviewReports.values();
    }

    public List<Report<Place>> getPlaceReports() {
        ArrayList<Report<Place>> reports = new ArrayList<Report<Place>>();
        for (Report<Place> report : placeReports.values()) {
            if(!report.isResolved())
                reports.add(report);
        }
        return reports;
    }

    public List<Report<User>> getUserReports() {
        return (ArrayList<Report<User>>) userReports.values();
    }

    public List<User> getBannedUsers() {
        return (List<User>) bannedUsers.values();
    }

    public void addBannedUser(User user) {
        bannedUsers.put(user.getId(), user);
    }

    //public void removeReport(long reportId) {
//        reports.remove(reportId);
//    }
}
