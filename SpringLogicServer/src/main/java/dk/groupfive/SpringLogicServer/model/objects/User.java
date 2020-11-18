package dk.groupfive.SpringLogicServer.model.objects;

import java.io.Serializable;

public class User implements Serializable
{

  private String username;
  private String password;
  private int auth;


  public User (String username,String password, int auth){
    this.username = username;
    this.password = password;
    this.auth=auth;
  }

  public String getUsername()
  {
    return username;
  }

  public void setUsername(String username)
  {
    this.username = username;
  }

  public String getPassword()
  {
    return password;
  }

  public void setPassword(String password)
  {
    this.password = password;
  }

  public int getAuth()
  {
    return auth;
  }

  public void setAuth(int auth)
  {
    this.auth = auth;
  }
}
