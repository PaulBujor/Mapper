package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.util.ArrayList;
import java.util.List;

public class PlaceImpl implements PlaceNetwork
{
  //TODO TCP connection to tier 3
   private List<Place> places;
   Place place1 = new Place(1,2,3);
   Place place2 = new Place(2,3,4);

   public PlaceImpl(){
     this.places = new ArrayList<>();
   }

  @Override public List<Place> getAllPlaces()
  {
   places.add(place1);
   places.add(place2);

    return places;
  }

  @Override public Place getPlaceById(long id )
  {
    return place1;
  }

  @Override public Place addPlace(long id, double latitude, double longitude)
  {
 places.add(new Place(id,latitude,longitude));
 return null;
  }

  @Override public void updatePlace(long id, double latitude, double longitude)
  {

  }

  @Override public void deletePlace(long id)
  {

  }
}
