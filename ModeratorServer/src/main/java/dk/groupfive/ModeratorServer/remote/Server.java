package dk.groupfive.ModeratorServer.remote;

import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Review;
import dk.groupfive.ModeratorServer.model.objects.User;

public interface Server {
    boolean authenticateUser(User user);

    void removePlace(Place place);

    void removeReview(Review review);

    void banUser(User user);

    void unbanUser(User user);
}
