package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Review;
import dk.groupfive.SpringLogicServer.model.objects.obsolete.ReviewItem;

import java.util.List;

public interface PlaceNetwork {
    List<Place> getAllPlaces();

    Place getPlaceByID(long id);

    void addPlace(Place place);

    void updatePlace(Place place);

    void deletePlace(long id);

    void addPlaceReview(long id, Review reviewItem);
}
