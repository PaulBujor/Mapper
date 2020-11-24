package dk.groupfive.ModeratorServer.model.objects;

public class Review {
    private long id;
    private int rating;
    private String title;
    private String description;

    public Review(long id, int rating, String title, String description) {
        this.id = id;
        this.rating = rating;
        this.title = title;
        this.description = description;
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

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
