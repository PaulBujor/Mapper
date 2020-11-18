package dk.groupfive.ModeratorServer.remote;

import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Review;
import dk.groupfive.ModeratorServer.model.objects.User;

import java.util.Collection;

public interface Server {
    boolean authenticateUser(User user) throws Exception;

//    void removePlace(Place place);
//
//    void removeReview(Review review);
//
//
//    Collection<Review> getAllReviews();
//
//    Collection<User> getAllUsers();
//
//    User removeUser(User user);
}
