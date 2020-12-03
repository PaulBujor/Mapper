package dk.groupfive.SpringLogicServer.local;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Report;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.math.BigInteger;
import java.util.*;

public class Cache {
    private Map<Long, Place> places;

    public Cache() {
        places = new HashMap<Long, Place>();
    }

    public void load(List<Place> places) {
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

}
