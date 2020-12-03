package dk.groupfive.ModeratorServer.remote;

import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Report;
import dk.groupfive.ModeratorServer.model.objects.User;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public interface Server {
    boolean authorizeUser(User user) throws Exception;

    List<Report<Place>> getPlaceReports() throws IOException;

    //using just id to save some bandwidth
    void removePlace(long placeId);

    void removeReview(long reviewId);

    void banUser(long userId);

    void unbanUser(long userId);

    void dismissReport(long reportId);
}
