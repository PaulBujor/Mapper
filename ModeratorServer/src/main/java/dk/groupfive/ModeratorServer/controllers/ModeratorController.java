package dk.groupfive.ModeratorServer.controllers;

import dk.groupfive.ModeratorServer.model.Model;
import dk.groupfive.ModeratorServer.model.ModeratorModel;
import dk.groupfive.ModeratorServer.model.objects.*;
import dk.groupfive.ModeratorServer.network.ModeratorNetwork;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ModeratorController implements ModeratorNetwork {
    private Model model;

    @Autowired
    public ModeratorController() {
        model = ModeratorModel.getInstance();
    }

//    @GetMapping("/reports")
//    public List<Report> getReports() {
//        return model.getReports();
//    }
//
//    @GetMapping("/reports/{id}")
//    public Report getReport(@PathVariable long id) {
//        return model.getReport(id);
//    }

    @GetMapping("/reports/places")
    public List<Report<Place>> getPlaceReports() {
        return model.getPlaceReports();
    }

    @GetMapping("/reports/reviews")
    public List<Report<Review>> getReviewReports() {
        return model.getReviewReports();
    }

    @GetMapping("/reports/users")
    public List<Report<UserData>> getUserReports() {
        return model.getUserReports();
    }

    @GetMapping("/bannedUsers")
    public List<UserData> getBannedUsers() {
        return model.getBannedUsers();
    }

    //not that restful but it works
    @PatchMapping("/reports/places")
    public void resolvePlace(@RequestParam long placeId, @RequestParam String action) {
        model.resolvePlace(placeId, action);
        System.out.println(placeId);
    }

    //currently the only action is remove
    @PatchMapping("/reports/reviews")
    public void resolveReview(@RequestParam long reviewId, @RequestParam String action) {
        model.resolveReview(reviewId, action);
    }

    //example: to ban a user you'd call with action=ban
    @PatchMapping("/reports/users")
    public void resolveUser(@RequestParam long userId, @RequestParam String action) {
        model.resolveUser(userId, action);
    }

    //maybe should use patch instead, but the url is already used,
    @PutMapping("/reports/places/dismissed")
    public void dismissPlaceReport(@RequestParam long reportId) {
        model.dismissPlaceReport(reportId);
    }

    @PutMapping("/reports/reviews/dismissed")
    public void dismissReviewReport(@RequestParam long reportId) {
        model.dismissReviewReport(reportId);
    }

    @PutMapping("/reports/users/dismissed")
    public void dismissUserReport(@RequestParam long reportId) {
        model.dismissUserReport(reportId);
    }



    /* PLACE cases */
    //GET REVIEWS
    //@RequestMapping(name = "/reviews", method = RequestMethod.GET)


    /*
    //PUT BAN USER
    @PatchMapping("/users/ban/{id}")
    @ResponseStatus(HttpStatus.OK)
    public void banUser(@PathVariable long id) {
        model.banUser(id);
    }


    //PUT UNBAN USER
    @PatchMapping("/users/unban/{id}")
    @ResponseStatus(HttpStatus.OK)
    public void unbanUser(@PathVariable long id) {
        model.unbanUser(id);
    }

    // USER cases
    //DELETE USER

    //todo probably we wont be deleting users

    @RequestMapping(name = "/users", method = RequestMethod.DELETE)
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void removeUser(User user) {
        return server.removeUser(user);
    }

        //POST UNBAN USER
    @RequestMapping(value = "/users", method = RequestMethod.POST)
    //@PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public void PostUnbanUser(@RequestBody User user) {
        try {
            if (!(user == null)) // && user exists
            {
                return server.unbanUser(user);
            }
        } catch (RuntimeException e) {
            System.out.println(e.getMessage());
        }
        return null;
    }


    //todo but we will be bringing the ban hammer to the game :D
    //POST BAN USER
    @RequestMapping(name = "/users", method = RequestMethod.POST)
    @ResponseStatus(HttpStatus.CREATED)
    public void PostBannedUser(User user) {
        return server.banUser(user);
    }

     */


}
