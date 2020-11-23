package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;
import java.util.List;

public interface Server {
    List<Place> getAllPlaces() throws IOException;

    Place getPlaceByID(long id);

    Place addPlace(Place place) throws IOException;

    void updatePlace(Place place);

    void deletePlace(long id);

    User validate(LoginMessage loginMessage) throws IOException;
    void register();


}
