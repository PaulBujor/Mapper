package dk.groupfive.ModeratorServer.model.objects.obsolete;

import java.util.List;

public interface IReview {
    double getRating();
    List<ReviewItem> getReviews();
}
