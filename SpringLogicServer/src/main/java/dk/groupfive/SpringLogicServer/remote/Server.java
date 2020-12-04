package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.*;

import java.io.IOException;
import java.util.List;

public interface Server {
    List<Place> getAllPlaces() throws IOException;

    Place getPlaceByID(long id);

    Place addPlace(Place place) throws IOException;

    ReviewItem addPlaceReview(long id, ReviewItem reviewItem) throws IOException;

    void updatePlace(Place place);

    void deletePlace(long id);

    void addReportPlace(Report<Place> report) throws IOException;

    void addReportUser(Report<User> report) throws IOException;

    void addReportReview(Report<ReviewItem> report) throws IOException;


}
