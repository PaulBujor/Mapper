package dk.groupfive.SpringLogicServer.model.tasks;


import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.io.Serializable;

public class PlaceTask implements Serializable {
    private String taskName;
    private Place place;
    private long placeID;

    public PlaceTask(String taskName, Place place) {
        this.taskName = taskName;
        this.place = place;
    }

    public PlaceTask(String taskName, long id) {
        this.taskName = taskName;
        placeID = id;
    }

    public String getTaskName() {
        return taskName;
    }

    public Place getPlace() {
        return place;
    }

    public long getPlaceID() {
        return placeID;
    }
}
