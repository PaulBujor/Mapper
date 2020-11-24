package dk.groupfive.ModeratorServer.model.objects;

import java.util.List;

public class ReviewLite implements IReview {
    private double rating;

    public ReviewLite(double rating) {
        this.rating = rating;
    }

    @Override
    public double getRating() {
        return rating;
    }

    @Override
    public List<ReviewItem> getReviews() {
        return null;
    }
}
