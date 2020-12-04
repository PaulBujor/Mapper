package dk.groupfive.SpringLogicServer.model.objects;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class ReviewFull implements IReview, Serializable {
    private ArrayList<ReviewItem> reviews;

    public ReviewFull() {
        /*reviews = new ArrayList<>();*/
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

    public void addReview(ReviewItem reviewItem)
    {
        reviews.add(reviewItem);
    }

    @Override
    public String toString() {
        return "ReviewFull{" +
                "reviews=" + reviews +
                '}';
    }
}
