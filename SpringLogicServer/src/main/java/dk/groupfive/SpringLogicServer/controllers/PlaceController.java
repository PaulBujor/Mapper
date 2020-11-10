package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.Place;
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
        return model.getAllPlaces();
    }

    @GetMapping(path = "/places/{id}")
    public @ResponseBody
    Place getPlaceByID(@PathVariable("id") long id) {
        return model.getPlaceByID(id);
    }


/*  com.fasterxml.jackson.databind.exc.InvalidDefinitionException: Cannot construct instance of `dk.groupfive.SpringLogicServer.model.objects.Place` (no Creators, like default constructor, exist): cannot deserialize from Object value (no delegate- or property-based Creator)
  at [Source: (PushbackInputStream); line: 1, column: 2]*/


    /*@RequestMapping(value = "/places", method = RequestMethod.POST)*//*
  @PostMapping(value = "/testing", consumes = "application/json",produces = "application/json")*/
    @PostMapping(value = "/places")
    @ResponseStatus(HttpStatus.CREATED)
    //todo make this respond with just OK instead of returning place, place will be returned by another service
    public void addPlace(@RequestBody Place place) {
        model.addPlace(place);
   /* try
    {
      return placeNetwork.addPlace(place);
    }
    catch (RuntimeException e)
    {
      e.printStackTrace();
      throw e;
    }*/
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
