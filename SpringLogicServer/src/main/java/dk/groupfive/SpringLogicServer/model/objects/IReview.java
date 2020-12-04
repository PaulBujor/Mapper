package dk.groupfive.SpringLogicServer.model.objects;

import java.util.List;

public interface IReview {
    double getRating();
    List<ReviewItem> getReviews();
    void addReview(ReviewItem reviewItem);
}
