package dk.groupfive.SpringLogicServer.model.objects;

public class Place
{
  //TODO add descriptions, users etc
  private long id;
  private double latitude;
  private double longitude;
  private String title;
  private String description;



  public Place(long id,double latitude, double longitude,String title, String description){
    this.id=id;
    this.latitude = latitude;
    this.longitude = longitude;
    this.title= title;
    this.description = description;
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

  public String getTitle(){
    return this.title;

  }

  public String getDescription(){
    return this.description;
  }

}
