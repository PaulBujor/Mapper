package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.network.PlaceNetwork;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.yaml.snakeyaml.constructor.DuplicateKeyException;

import javax.validation.Valid;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/places")
public class PlaceController
{

  private PlaceNetwork placeNetwork;



  @Autowired
  public PlaceController(){

  }
  @GetMapping("/places") List<Place> all(){
    return placeNetwork.getAllPlaces();

  }

  @PostMapping
  @ResponseStatus(HttpStatus.CREATED)
  public Place create(@RequestBody Place place)
  {
    try
    {
      return placeNetwork.addPlace(place.getId(), place.getLatitude(), place.getLongitude());
    }
    catch (RuntimeException e){
      e.printStackTrace();
      throw e;
    }
    }

    /*@PatchMapping("{id}")
    public ResponseEntity<Void> updatePlace(@PathVariable("id") long id,@Valid @RequestBody Place place){

    //Todo this patching is confusing, will come back to fix it

    placeNetwork.updatePlace(1,2,3);

    return  ResponseEntity.notFound().build();
    }*/





    @DeleteMapping(value = "/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void delete(@PathVariable("id") Long id){
    placeNetwork.deletePlace(id);
    }


}
