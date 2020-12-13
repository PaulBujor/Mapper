package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.*;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;

public interface ReportNetwork {
    void addReportPlace(Report<Place> report);
    void addReportUser(Report<UserData> report);
    void addReportReview(Report<Review> report);
}
