package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Report;
import dk.groupfive.SpringLogicServer.model.objects.ReviewItem;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;

public interface ReportNetwork {
    void addReportPlace(Report<Place> report);
    void addReportUser(Report<User> report);
    void addReportReview(Report<ReviewItem> report);
}
