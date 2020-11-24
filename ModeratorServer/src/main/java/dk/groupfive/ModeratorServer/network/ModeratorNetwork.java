package dk.groupfive.ModeratorServer.network;

import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Report;
import dk.groupfive.ModeratorServer.model.objects.Review;
import dk.groupfive.ModeratorServer.model.objects.User;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PatchMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;

public interface ModeratorNetwork {
    List<Report> getReports();

    Report getReport(long id);

    List<Report<Place>> getPlaceReports();

    List<Report<Review>> getReviewReports();

    List<Report<User>> getUserReports();

    void resolvePlace(long reportId, String action);

    void resolveReview(long reportId, String action);

    void resolveUser(long reportId, String action);
}
