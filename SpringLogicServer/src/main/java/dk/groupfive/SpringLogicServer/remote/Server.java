package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.objects.*;

import java.io.IOException;
import java.util.List;

public interface Server {
    List<Place> getAllPlaces() throws IOException;

    Place getPlaceByID(long id);

    Place addPlace(Place place) throws IOException;

    Review addPlaceReview(long id, Review reviewItem) throws IOException;

    void updatePlace(Place place);

    void deletePlace(long id);

    void addReportPlace(Report<Place> report) throws IOException;

    void addReportUser(Report<UserData> report) throws IOException;

    void addReportReview(Report<Review> report) throws IOException;

    void addSavedPlace(long userId, long placeId);

    void removeSavedPlace(long userId, long placeId);
}
