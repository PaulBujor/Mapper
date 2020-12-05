package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Report;
import dk.groupfive.SpringLogicServer.model.objects.Review;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;
import dk.groupfive.SpringLogicServer.model.objects.User;

public interface ReportNetwork {
    void addReportPlace(Report<Place> report);
    void addReportUser(Report<User> report);
    void addReportReview(Report<Review> report);
}
