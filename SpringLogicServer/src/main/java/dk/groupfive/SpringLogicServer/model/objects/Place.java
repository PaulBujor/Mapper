package dk.groupfive.SpringLogicServer.model.objects;

import java.io.Serializable;

public class Place implements Serializable {
    private long Id;
    private double Latitude;
    private double Longitude;
    private String Title;
    private String Description;


    public Place() {
        super();
    }

    public Place(long id, double latitude, double longitude, String title, String description) {
        this.Id = id;
        this.Latitude = latitude;
        this.Longitude = longitude;
        this.Title = title;
        this.Description = description;
    }

    public long getId() {
        return this.Id;
    }

    public double getLatitude() {
        return this.Latitude;
    }

    public double getLongitude() {
        return this.Longitude;
    }

    public String getTitle() {
        return this.Title;
    }

    public String getDescription() {
        return this.Description;
    }

    public void setId(long id) {
        this.Id = id;
    }

    public void setLatitude(double latitude) {
        this.Latitude = latitude;
    }

    public void setLongitude(double longitude) {
        this.Longitude = longitude;
    }

    public void setTitle(String title) {
        this.Title = title;
    }

    public void setDescription(String description) {
        this.Description = description;
    }

    @Override
    public String toString() {
        return "Place{" +
                "id=" + Id +
                ", latitude=" + Latitude +
                ", longitude=" + Longitude +
                ", title='" + Title + '\'' +
                ", description='" + Description + '\'' +
                '}';
    }
}
