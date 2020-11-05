package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.Place;

import java.util.List;

public interface PlaceNetwork
{
  List<Place> getAllPlaces();
  Place getPlaceById(long id);
  Place addPlace(long id, double latitude, double longitude);
  Place updatePlace(long id, double latitude,double longitude);
  Place deletePlace(long id);



}
