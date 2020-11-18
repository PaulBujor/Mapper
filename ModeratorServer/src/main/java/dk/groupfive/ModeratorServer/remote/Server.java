package dk.groupfive.ModeratorServer.remote;

import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Review;
import dk.groupfive.ModeratorServer.model.objects.User;

import java.util.Collection;

public interface Server {
    boolean authenticateUser(User user) throws Exception;

    //using just id to save some bandwidth
    void removePlace(long placeId);

    void removeReview(long reviewId);

    void banUser(long userId);

    void unbanUser(long userId);
}
