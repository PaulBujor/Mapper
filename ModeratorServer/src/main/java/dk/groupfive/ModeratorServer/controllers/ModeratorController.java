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
    public List<Report<ReviewItem>> getReviewReports() {
        return model.getReviewReports();
    }

    @GetMapping("/reports/users")
    public List<Report<User>> getUserReports() {
        return model.getUserReports();
    }

    //not that restful but it works
    @PatchMapping("/reports/places/{reportId}?action={action}")
    public void resolvePlace(@PathVariable long reportId, @PathVariable String action) {
        model.resolvePlace(reportId, action);
    }

    @PatchMapping("/reports/reviews/{reportId}?action={action}")
    public void resolveReview(@PathVariable long reportId, @PathVariable String action) {
        model.resolveReview(reportId, action);
    }

    @PatchMapping("/reports/users/{reportId}?action={action}")
    public void resolveUser(@PathVariable long reportId, @PathVariable String action) {
        model.resolveUser(reportId, action);
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
