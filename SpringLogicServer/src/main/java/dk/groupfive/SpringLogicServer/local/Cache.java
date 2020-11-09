package dk.groupfive.SpringLogicServer.local;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

public class Cache implements Model {
    private List<Place> places;

    public Cache() {
        places = new ArrayList<Place>();
    }

    public void load(List<Place> places) {
        this.places = places;
    }

    @Override
    public List<Place> getAllPlaces() {
        return places;
    }

    @Override
    public Place getPlaceByID(long id) {
        for (Place place : places) {
            if (place.getId() == id)
                return place;
        }
        throw new NoSuchElementException("Place with id: " + id + " was not found!");
    }

    @Override
    public void addPlace(Place place) {
        places.add(place);
    }

    @Override
    public void updatePlace(Place place) {
        getPlaceByID(place.getId()); //todo update data, eventually add update/set method in Place object
    }

    @Override
    public void deletePlace(long id) {
        places.remove(getPlaceByID(id));
    }
}
