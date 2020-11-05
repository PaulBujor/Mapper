package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.util.ArrayList;
import java.util.List;

public class PlaceImpl implements PlaceNetwork
{
  //TODO TCP connection to tier 3
   private List<Place> places;

   public PlaceImpl(){
     this.places = new ArrayList<>();
   }

  @Override public List<Place> getAllPlaces()
  {
    places.add(0,new Place(1,2,3));
    places.add(1,new Place(2,2,3));
    places.add(2,new Place(3,2,3));
    places.add(3,new Place(4,2,3));
    System.out.println(places.size());
    return places;
  }

  @Override public Place getPlaceById(long id )
  {
    return null;
  }

  @Override public Place addPlace(long id, double latitude, double longitude)
  {
    return null;
  }

  @Override public Place updatePlace(long id, double latitude, double longitude)
  {
    return null;
  }

  @Override public Place deletePlace(long id)
  {
    return null;
  }
}
