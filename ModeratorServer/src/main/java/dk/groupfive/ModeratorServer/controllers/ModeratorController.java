package dk.groupfive.ModeratorServer.controllers;

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
        private Server server;

        @Autowired //enables you to inject the object dependency implicitly. It internally uses setter or constructor injection. Autowiring can't be used to inject primitive and string values.
        public ModeratorController(Server server/*Review reviewDAO, User userDAO*/){
            this.server = server;
        }

        /* REVIEWS cases */
        //GET REVIEWS
        @RequestMapping(name = "/reviews", method = RequestMethod.GET)
        //@GetMapping
        public List<Review> getAllReviews(){
            return (List<Review>) server.getAllReviews();
        }

        /* USER cases */
        //DELETE USER
        @RequestMapping(name = "/users", method = RequestMethod.DELETE)
        @ResponseStatus(HttpStatus.NO_CONTENT)
        public User removeUser(User user){
            return server.removeUser(user);
        }

        //POST BAN USER
        @RequestMapping(name="/users", method = RequestMethod.POST)
        @ResponseStatus(HttpStatus.CREATED)
        public User PostBannedUser(User user){
            return server.banUser(user);
        }

        //PUT BAN USER
        @RequestMapping(name = "/users", method = RequestMethod.PUT)
        @ResponseStatus(HttpStatus.OK)
        public User PutBannedUser(User user){
            return server.banUser(user);
        }


        //POST UNBAN USER
        @RequestMapping(value = "/users", method = RequestMethod.POST)
        //@PostMapping
        @ResponseStatus(HttpStatus.CREATED)
        public User PostUnbanUser(@RequestBody User user){
            try{
                if (!(user == null)) // && user exists
                {
                    return server.unbanUser(user);
                }
            } catch(RuntimeException e){
                System.out.println(e.getMessage());
            }
            return null;
        }

        //PUT UNBAN USER
        @RequestMapping(value = "/users", method = RequestMethod.PUT)
        @ResponseStatus(HttpStatus.OK)
        //@PutMapping
        public User PutUnbanUser(User user){
            return server.unbanUser(user);
        }

    }
