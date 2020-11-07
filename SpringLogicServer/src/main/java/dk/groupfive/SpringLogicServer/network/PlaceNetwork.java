package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.util.List;

public interface PlaceNetwork
{
  List<Place> getAllPlaces();
  Place getPlaceById(long id);
  Place addPlace(Place place);
  void updatePlace(long id, double latitude,double longitude,String title,String description);
  void deletePlace(long id);



}
