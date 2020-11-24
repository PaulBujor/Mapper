package dk.groupfive.ModeratorServer.network;

import dk.groupfive.ModeratorServer.model.objects.*;

import java.util.List;

public interface ModeratorNetwork {
    List<Report<Place>> getPlaceReports();

    List<Report<ReviewItem>> getReviewReports();

    List<Report<User>> getUserReports();

    void resolvePlace(long reportId, String action);

    void resolveReview(long reportId, String action);

    void resolveUser(long reportId, String action);
}
