package dk.groupfive.ModeratorServer.controllers;

import dk.groupfive.ModeratorServer.model.Model;
import dk.groupfive.ModeratorServer.model.ModeratorModel;
import dk.groupfive.ModeratorServer.model.objects.Place;
import dk.groupfive.ModeratorServer.model.objects.Report;
import dk.groupfive.ModeratorServer.model.objects.Review;
import dk.groupfive.ModeratorServer.model.objects.User;
import dk.groupfive.ModeratorServer.network.ModeratorNetwork;
import dk.groupfive.ModeratorServer.remote.Server;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ModeratorController implements ModeratorNetwork { //todo interface
    private Model model;

    @Autowired
    public ModeratorController() {
        model = ModeratorModel.getInstance();
    }

    @GetMapping("/reports")
    public List<Report> getReports() {
        return model.getReports();
    }

    @GetMapping("/reports/{id}")
    public Report getReport(@PathVariable long id) {
        return model.getReport(id);
    }

    @PutMapping("/reports/{id}")
    public void resolveReport(@RequestBody String action, @PathVariable long id) {
        model.resolveReport(action, id);
    }

    /* PLACE cases */
    //GET REVIEWS
    //@RequestMapping(name = "/reviews", method = RequestMethod.GET)
    @GetMapping("/reports/places")
    public List<Report<Place>> getPlaceReports() {
        return model.getPlaceReports();
    }

    /* REVIEWS cases */
    //GET REVIEWS
    //@RequestMapping(name = "/reviews", method = RequestMethod.GET)
    @GetMapping("/reports/reviews")
    public List<Report<Review>> getReviewReports() {
        return model.getReviewReports();
    }

    //PUT BAN USER
    @RequestMapping(name = "/users", method = RequestMethod.PUT)
    @ResponseStatus(HttpStatus.OK)
    public void banUser(User user) {
        model.banUser(user);
    }


    //PUT UNBAN USER
    @RequestMapping(value = "/users", method = RequestMethod.PUT)
    @ResponseStatus(HttpStatus.OK)
    //@PutMapping
    public void unbanUser(User user) {
        model.unbanUser(user);
    }

    /*
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
