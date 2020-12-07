package dk.groupfive.ModeratorServer.model.objects;

import java.io.Serializable;
import java.util.ArrayList;

public class Place implements Serializable {
    private long id;
    private double latitude;
    private double longitude;
    private String title;
    private String description;
    private ArrayList<Review> reviews;
    private UserData addedBy;

    public Place() {

    }

    public Place(long id, double latitude, double longitude, String title, String description) {
        this.id = id;
        this.latitude = latitude;
        this.longitude = longitude;
        this.title = title;
        this.description = description;
    }

    public Place(double latitude, double longitude, String title, String description) {
        this.latitude = latitude;
        this.longitude = longitude;
        this.title = title;
        this.description = description;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public double getLatitude() {
        return latitude;
    }

    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    public double getLongitude() {
        return longitude;
    }

    public void setLongitude(double longitude) {
        this.longitude = longitude;
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

    public ArrayList<Review> getReviews() {
        return reviews;
    }

    public void setReviews(ArrayList<Review> reviews) {
        this.reviews = reviews;
    }

    public void addReview(Review reviewItem)
    {
        reviews.add(reviewItem);
    }

    public UserData getAddedBy() {
        return addedBy;
    }

    public void setAddedBy(UserData addedBy) {
        this.addedBy = addedBy;
    }

    @Override
    public String toString() {
        return "Place{" +
                "id=" + id +
                ", latitude=" + latitude +
                ", longitude=" + longitude +
                ", title='" + title + '\'' +
                ", description='" + description + '\'' +
                '}';
    }
}
