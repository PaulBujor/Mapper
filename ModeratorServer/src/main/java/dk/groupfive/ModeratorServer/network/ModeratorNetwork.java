package dk.groupfive.ModeratorServer.network;

import dk.groupfive.ModeratorServer.model.objects.*;

import java.util.List;

public interface ModeratorNetwork {
    List<Report<Place>> getPlaceReports();

    List<Report<ReviewItem>> getReviewReports();

    List<Report<User>> getUserReports();

    void resolvePlace(long placeId, String action);

    void resolveReview(long reviewId, String action);

    void resolveUser(long userId, String action);

    void resolveReport(long reportId, String action);
}
