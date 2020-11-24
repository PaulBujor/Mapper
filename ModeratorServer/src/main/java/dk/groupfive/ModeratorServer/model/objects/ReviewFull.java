package dk.groupfive.ModeratorServer.model.objects;

import java.util.ArrayList;
import java.util.List;

public class ReviewFull implements IReview {
    private ArrayList<ReviewItem> reviews;

    public ReviewFull() {
        reviews = new ArrayList<>();
    }

    @Override
    public double getRating() {
        long score = 0;
        for (ReviewItem item : reviews)
        {
            score += item.getRating();
        }
        return (double) score / reviews.size();
    }

    @Override
    public List<ReviewItem> getReviews() {
        return reviews;
    }
}
