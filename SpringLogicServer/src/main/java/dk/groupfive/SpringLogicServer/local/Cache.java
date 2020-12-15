package dk.groupfive.SpringLogicServer.local;

import dk.groupfive.SpringLogicServer.model.objects.*;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;

import java.util.*;

public class Cache {
    private Map<Long, Place> places;

    public Cache() {
        places = new HashMap<Long, Place>();
    }

    public void load(List<Place> places) {
        places.clear();
        for (Place place : places) {
            this.places.put(place.getId(), place);
        }
    }


    public List<Place> getAllPlaces() {
        return new ArrayList<Place>(places.values());
    }


    public Place getPlaceByID(long id) {
        if (places.containsKey(id))
            return places.get(id);
        throw new NoSuchElementException("Place with id: " + id + " was not found!");
    }


    public void addPlace(Place place) {
        places.put(place.getId(), place);
    }


    public void updatePlace(Place place) {
        places.put(place.getId(), place);
    }

    public void deletePlace(long id) {
        places.remove(id);
    }

    public void addPlaceReview(long id, Review reviewItem)
    {
        places.get(id).addReview(reviewItem);
    }

    public void addSavedPlace(long userId, long placeId)
    {

    }

}
