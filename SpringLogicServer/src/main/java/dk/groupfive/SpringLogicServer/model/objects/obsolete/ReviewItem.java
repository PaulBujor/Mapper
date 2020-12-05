package dk.groupfive.SpringLogicServer.model.objects.obsolete;

import java.io.Serializable;

public class ReviewItem implements Serializable {
    private long id;
    private int rating;
    private String comment;

    public ReviewItem() {
    }

    public ReviewItem(int rating, String comment) {
        this.rating = rating;
        this.comment = comment;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public long getId() {
        return id;
    }

    @Override
    public String toString() {
        return "ReviewItem{" +
                "id=" + id +
                ", rating=" + rating +
                ", comment='" + comment + '\'' +
                '}';
    }
}
