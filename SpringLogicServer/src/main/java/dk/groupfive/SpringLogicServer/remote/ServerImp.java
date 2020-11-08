package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.util.List;

public class ServerImp implements Server {
    //todo tcp socket to tier 3

    @Override
    public List<Place> getAllPlaces() {
        return null;
    }

    @Override
    public Place getPlaceByID(long id) {
        return null;
    }

    //todo this should wait for a place with id from the server, then return it
    @Override
    public Place addPlace(Place place) {
        return null;
    }

    @Override
    public void updatePlace(Place place) {

    }

    @Override
    public void deletePlace(long id) {

    }
}
