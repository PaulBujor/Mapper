package dk.groupfive.SpringLogicServer.model.objects;

import java.io.Serializable;

public class Message implements Serializable
{
  public String text;

  public Message(){};
  public Message(String text){
    this.text=text;
  }

  public String getText()
  {
    return this.text;
  }

  public void setText(String text)
  {
    this.text = text;
  }
}
