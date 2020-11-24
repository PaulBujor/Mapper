package dk.groupfive.ModeratorServer.model.objects;

import java.util.List;

public interface IReview {
    double getRating();
    List<ReviewItem> getReviews();
}
