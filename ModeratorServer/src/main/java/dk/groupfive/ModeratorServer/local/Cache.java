package dk.groupfive.ModeratorServer.local;

import dk.groupfive.ModeratorServer.model.objects.*;
import dk.groupfive.ModeratorServer.model.objects.obsolete.ReviewItem;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Cache {
    private Map<Long, Report<Place>> placeReports;
    private Map<Long, Report<Review>> reviewReports;
    private Map<Long, Report<UserData>> userReports;
    private Map<Long, UserData> bannedUsers;

    public Cache() {
        placeReports = new HashMap<>();
        reviewReports = new HashMap<>();
        userReports = new HashMap<>();
        bannedUsers = new HashMap<>();
    }

    public void loadPlaceReports(List<Report<Place>> reports) {
        for (Report<Place> report : reports) {
            placeReports.put(report.getReportId(), report);
        }
    }

    public void loadReviewReports(List<Report<Review>> reports) {
        for (Report<Review> report : reports) {
            reviewReports.put(report.getReportId(), report);
        }
    }

    public void loadUserReports(List<Report<UserData>> reports) {
        for (Report<UserData> report : reports) {
            userReports.put(report.getReportId(), report);
        }
    }

    public void loadBannedUsers(List<UserData> users) {
        for (UserData user : users) {
            bannedUsers.put(user.getUserId(), user);
        }
    }

    //public Report getReport(long id) {
//        return reports.get(id);
//    }

    public List<Report<Review>> getReviewReports() {
        ArrayList<Report<Review>> reports = new ArrayList<Report<Review>>();
        for (Report<Review> report : reviewReports.values()) {
            if (!report.isResolved())
                reports.add(report);
        }
        return reports;
    }

    public List<Report<Place>> getPlaceReports() {
        ArrayList<Report<Place>> reports = new ArrayList<Report<Place>>();
        for (Report<Place> report : placeReports.values()) {
            if (!report.isResolved())
                reports.add(report);
        }
        return reports;
    }

    public List<Report<UserData>> getUserReports() {
        ArrayList<Report<UserData>> reports = new ArrayList<Report<UserData>>();
        for (Report<UserData> report : userReports.values()) {
            if (!report.isResolved())
                reports.add(report);
        }
        return reports;
    }

    public List<UserData> getBannedUsers() {
        ArrayList<UserData> banned = new ArrayList<UserData>();
        for (UserData user : bannedUsers.values()) {
            banned.add(user);
        }
        return banned;
    }

    public void addBannedUser(UserData user) {
        bannedUsers.put(user.getUserId(), user);
    }

    //public void removeReport(long reportId) {
//        reports.remove(reportId);
//    }
}
