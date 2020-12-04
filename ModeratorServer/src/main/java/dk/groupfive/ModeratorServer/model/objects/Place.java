package dk.groupfive.ModeratorServer.model.objects;

import java.io.Serializable;
import java.util.ArrayList;

public class Place implements Serializable {
    private long id;
    private double latitude;
    private double longitude;
    private String title;
    private String description;
    private ReviewFull reviews;


    public Place() {
    }

    public Place(long id, double latitude, double longitude, String title, String description, ReviewFull reviews) {
        this.id = id;
        this.latitude = latitude;
        this.longitude = longitude;
        this.title = title;
        this.description = description;
        this.reviews = reviews;
    }

    public Place(double latitude, double longitude, String title, String description, ReviewFull reviews) {
        this.latitude = latitude;
        this.longitude = longitude;
        this.title = title;
        this.description = description;
        this.reviews = reviews;
    }

    public long getId() {
        return id;
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

    public IReview getReviews() {
        return reviews;
    }

    public void setReviews(ReviewFull reviews) {
        this.reviews = reviews;
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
