package dk.groupfive.SpringLogicServer.model.objects;

import java.io.Serializable;

public class User implements Serializable
{

  private String username;
  private String password;
  private String email;
  private int auth;
  private String firstname;
  private String lastname;
  private long id;


  public User(){super();}
  public User (String username,String password,String email, int auth,String firstname,String lastname,long id){
    this.username = username;
    this.password = password;
    this.email = email;
    this.auth= auth;
    this.firstname = firstname;
    this.lastname = lastname;
    this.id=id;
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

  public String getEmail()
  {
    return email;
  }

  public void setEmail(String email)
  {
    this.email = email;
  }

  public String getFirstname()
  {
    return firstname;
  }

  public void setFirstname(String firstname)
  {
    this.firstname = firstname;
  }

  public String getLastname()
  {
    return lastname;
  }

  public void setLastname(String lastname)
  {
    this.lastname = lastname;
  }

  public long getId()
  {
    return id;
  }

  public void setId(long id)
  {
    this.id = id;
  }
}
