package dk.groupfive.ModeratorServer.remote;

import dk.groupfive.ModeratorServer.model.objects.*;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public interface Server {
    boolean authorizeUser(User user) throws Exception;

    List<Report<Place>> getPlaceReports() throws IOException;

    List<Report<UserData>> getUserReports() throws IOException;

    List<Report<Review>> getReviewReports() throws IOException;

    //using just id to save some bandwidth
    void removePlace(long placeId);

    void removeReview(long reviewId);

    void banUser(long userId);

    void unbanUser(long userId);

    void dismissPlaceReport(long reportId);

    void dismissReviewReport(long reportId);

    void dismissUserReport(long reportId);

    UserData getUserById(long userId) throws IOException;

    List<UserData> getBannedUsers() throws IOException;
}
