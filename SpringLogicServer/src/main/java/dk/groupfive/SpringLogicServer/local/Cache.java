package dk.groupfive.SpringLogicServer.local;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.util.*;

public class Cache implements Model {
    private Map<Long, Place> places;

    public Cache() {
        places = new HashMap<Long, Place>();
    }

    public void load(List<Place> places) {
        for (Place place : places) {
            this.places.put(place.getId(), place);
        }
    }

    @Override
    public List<Place> getAllPlaces() {
        return new ArrayList<Place>(places.values());
    }

    @Override
    public Place getPlaceByID(long id) {
        if (places.containsKey(id))
            return places.get(id);
        throw new NoSuchElementException("Place with id: " + id + " was not found!");
    }

    @Override
    public void addPlace(Place place) {
        places.put(place.getId(), place);
    }

    @Override
    public void updatePlace(Place place) {
        places.put(place.getId(), place);
    }

    @Override
    public void deletePlace(long id) {
        places.remove(id);
    }
}
