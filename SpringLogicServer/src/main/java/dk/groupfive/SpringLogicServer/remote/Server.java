package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.io.IOException;
import java.util.List;

public interface Server {
    List<Place> getAllPlaces() throws IOException;

    Place getPlaceByID(long id);

    Place addPlace(Place place);

    void updatePlace(Place place);

    void deletePlace(long id);
}
