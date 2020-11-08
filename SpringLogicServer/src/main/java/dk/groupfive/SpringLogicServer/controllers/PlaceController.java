package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.network.PlaceNetwork;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController

public class PlaceController implements PlaceNetwork{

    private PlaceNetwork placeNetwork;

    @Autowired
    public PlaceController() {

    }

    @GetMapping("/places")
    public List<Place> getAllPlaces() {
        List<Place> places = new ArrayList<>();
        Place blet = new Place(1, 2, 3, "aaa", "bbbb");
        Place blet1 = new Place(2, 3, 4, "aaa", "nnnn");
        places.add(blet);
        places.add(blet1);
        return places;

        /*return placeNetwork.getAllPlaces();*/

    }

    @GetMapping(path = "/places/{id}")
    public @ResponseBody
    Place getPlaceByID(@PathVariable("id") long id) {

        if (id == 1) {
            return new Place(1, 2, 3, "aaa", "cccc");
        }

        return placeNetwork.getPlaceByID(id);
    }


/*  com.fasterxml.jackson.databind.exc.InvalidDefinitionException: Cannot construct instance of `dk.groupfive.SpringLogicServer.model.objects.Place` (no Creators, like default constructor, exist): cannot deserialize from Object value (no delegate- or property-based Creator)
  at [Source: (PushbackInputStream); line: 1, column: 2]*/


    /*@RequestMapping(value = "/places", method = RequestMethod.POST)*//*
  @PostMapping(value = "/testing", consumes = "application/json",produces = "application/json")*/
    @PostMapping(value = "/places")
    @ResponseStatus(HttpStatus.CREATED) //todo make this respond with just OK instead of returning place, place will be returned by another service
    public void addPlace(@RequestBody Place place) {
        System.out.println(place.getId());
        System.out.println(place.getLatitude());
        System.out.println(place.getLongitude());
        System.out.println(place.getTitle());
        System.out.println(place.getDescription());
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
        placeNetwork.deletePlace(id);
    }

}
