package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.ReviewItem;
import dk.groupfive.SpringLogicServer.network.PlaceNetwork;
import dk.groupfive.SpringLogicServer.queue.ServerQueue;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController

public class PlaceController implements PlaceNetwork {
    private Model model;

    @Autowired
    public PlaceController() {
        model = ServerQueue.getInstance();
    }

    @GetMapping("/places")
    public List<Place> getAllPlaces() {
        System.out.println(model.getAllPlaces()); return model.getAllPlaces();
    }

    @GetMapping(path = "/places/{id}")
    public @ResponseBody
    Place getPlaceByID(@PathVariable("id") long id) {
        return model.getPlaceByID(id);
    }



    @PostMapping(value = "/places")
    @ResponseStatus(HttpStatus.CREATED)
    //todo make this respond with just OK instead of returning place, place will be returned by another service
    public void addPlace(@RequestBody Place place) {
        model.addPlace(place);

    }

    @PostMapping(value = "/places/{id}/reviews")
    @ResponseStatus(HttpStatus.CREATED)
    public void addPlaceReview(@PathVariable("id") long id, @RequestBody ReviewItem review) {
        model.addPlaceReview(id, review);
    }

    @PatchMapping("{id}")
    public void updatePlace(@RequestBody Place place) {
        //todo
    }

    @DeleteMapping(value = "/places/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deletePlace(@PathVariable("id") long id) {
        model.deletePlace(id);
    }
}
