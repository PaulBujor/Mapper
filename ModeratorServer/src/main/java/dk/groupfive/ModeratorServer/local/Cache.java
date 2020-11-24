package dk.groupfive.ModeratorServer.local;

import dk.groupfive.ModeratorServer.model.objects.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Cache {
    private Map<Long, Report> reports;

    public Cache() {
        reports = new HashMap<>();
    }

    public void loadReports(List<Report> reports) {
        for(Report<Place> report : reports) {
            this.reports.put(report.getReportId(), report);
        }
    }

    public List<Report> getReports() {
        return (List<Report>) reports.values();
    }

    public Report getReport(long id) {
        return reports.get(id);
    }

    public List<Report<ReviewItem>> getReviewReports() {
        List<Report<ReviewItem>> reviewReports = new ArrayList<>();
        for(Report report : reports.values()) {
            if (report.getReportedClass().equals("Review"))
                reviewReports.add((Report<ReviewItem>) report);
        }
        return reviewReports;
    }

    public List<Report<Place>> getPlaceReports() {
        List<Report<Place>> placeReports = new ArrayList<>();
        for(Report report : reports.values()) {
            if (report.getReportedClass().equals("Place"))
                placeReports.add((Report<Place>) report);
        }
        return placeReports;
    }

    public List<Report<User>> getUserReports() {
        List<Report<User>> placeReports = new ArrayList<>();
        for(Report report : reports.values()) {
            if (report.getReportedClass().equals("User"))
                placeReports.add((Report<User>) report);
        }
        return placeReports;
    }

    public void removeReport(long reportId) {
        reports.remove(reportId);
    }
}
