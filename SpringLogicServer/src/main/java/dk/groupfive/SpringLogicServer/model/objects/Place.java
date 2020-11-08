package dk.groupfive.SpringLogicServer.model.objects;

import java.io.Serializable;

public class Place implements Serializable {
    //TODO might have to change variable to Latitude, Description instead of latitude, description etc. -- compatibility issue between C# and Java classes
    private long id;
    private double latitude;
    private double longitude;
    private String title;
    private String description;


    public Place() {
        super();
    }

    public Place(long id, double latitude, double longitude, String title, String description) {
        this.id = id;
        this.latitude = latitude;
        this.longitude = longitude;
        this.title = title;
        this.description = description;
    }

    public long getId() {
        return this.id;
    }

    public double getLatitude() {
        return this.latitude;
    }

    public double getLongitude() {
        return this.longitude;
    }

    public String getTitle() {
        return this.title;
    }

    public String getDescription() {
        return this.description;
    }

    public void setId(long id) {
        this.id = id;
    }

    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
