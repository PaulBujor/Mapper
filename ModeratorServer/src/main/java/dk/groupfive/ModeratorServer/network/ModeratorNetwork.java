package dk.groupfive.ModeratorServer.network;

import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Report;
import dk.groupfive.ModeratorServer.model.objects.Review;
import dk.groupfive.ModeratorServer.model.objects.User;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;

public interface ModeratorNetwork {
    List<Report> getReports();

    Report getReport(long id);

    public void resolveReport(String action, long id);

    List<Report<Review>> getReviewReports();

    List<Report<Place>> getPlaceReports();

    void banUser(User user);

    void unbanUser(User user);
}
