package dk.groupfive.SpringLogicServer.model.objects;

public class Review {
    private long id;
    private int rating;
    private String comment;
    private UserData addedBy;

    public Review() {
    }

    public Review(long id, int rating, String comment, UserData addedBy) {
        this.id = id;
        this.rating = rating;
        this.comment = comment;
        this.addedBy = addedBy;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
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

    public UserData getAddedBy() {
        return addedBy;
    }

    public void setAddedBy(UserData addedBy) {
        this.addedBy = addedBy;
    }

    @Override
    public String toString() {
        return "Review{" +
                "id=" + id +
                ", rating=" + rating +
                ", comment='" + comment + '\'' +
                ", addedBy=" + addedBy +
                '}';
    }
}
