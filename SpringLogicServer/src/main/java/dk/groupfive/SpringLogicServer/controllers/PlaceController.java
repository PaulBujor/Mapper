package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.network.PlaceNetwork;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.yaml.snakeyaml.constructor.DuplicateKeyException;

import javax.validation.Valid;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController

public class PlaceController
{

  private PlaceNetwork placeNetwork;

  @Autowired public PlaceController()
  {

  }

  @GetMapping("/places") List<Place> all()
  {
    List<Place> places = new ArrayList<>();
    Place blet = new Place(1, 2, 3, "aaa", "bbbb");
    Place blet1 = new Place(2, 3, 4, "aaa", "nnnn");
    places.add(blet);
    places.add(blet1);
    return places;

    /*return placeNetwork.getAllPlaces();*/

  }

  @GetMapping(path = "/places/{id}")
  public @ResponseBody Place place(@PathVariable("id") long id)
  {

    if (id == 1)
    {
      return new Place(1, 2, 3, "aaa", "cccc");
    }

    return placeNetwork.getPlaceById(id);
  }


/*  com.fasterxml.jackson.databind.exc.InvalidDefinitionException: Cannot construct instance of `dk.groupfive.SpringLogicServer.model.objects.Place` (no Creators, like default constructor, exist): cannot deserialize from Object value (no delegate- or property-based Creator)
  at [Source: (PushbackInputStream); line: 1, column: 2]*/


  /*@RequestMapping(value = "/places", method = RequestMethod.POST)*//*
  @PostMapping(value = "/testing", consumes = "application/json",produces = "application/json")*/
  @PostMapping(value = "/testing")
  @ResponseStatus(HttpStatus.CREATED)
  public Place create(@RequestBody Place place)
  {
return place;
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

   /* @PatchMapping("{id}")
    public ResponseEntity<Void> updatePlace(@PathVariable("id") long id,@Valid @RequestBody Place place){

    //Todo this patching is confusing, will come back to fix it

    placeNetwork.updatePlace(1,2,3);

    return  ResponseEntity.notFound().build();
    }
*/

  @DeleteMapping(value = "/places/{id}")
  @ResponseStatus(HttpStatus.NO_CONTENT)
  public void delete(@PathVariable("id") Long id)
  {
    placeNetwork.deletePlace(id);
  }

}
