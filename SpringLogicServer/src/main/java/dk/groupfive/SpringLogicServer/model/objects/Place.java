package dk.groupfive.SpringLogicServer.model.objects;

public class Place
{
  //TODO add descriptions, users etc
  private long id;
  private double latitude;
  private double longitude;


  public Place(long id,double latitude, double longitude){
    this.id=id;
    this.latitude = latitude;
    this.longitude = longitude;

  }

  public long getId()
  {
    return this.id;
  }

  public double getLatitude(){
    return this.latitude;
  }

  public double getLongitude(){
    return this.longitude;
  }


}
