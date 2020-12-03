package dk.groupfive.SpringLogicServer.model;

import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;
import dk.groupfive.SpringLogicServer.remote.AuthClient;
import dk.groupfive.SpringLogicServer.remote.AuthServer;
import dk.groupfive.SpringLogicServer.remote.PlaceClient;
import dk.groupfive.SpringLogicServer.remote.Server;

import java.io.IOException;

public class ServerAccountModel implements AccountModel
{

  private static ServerAccountModel instance;
  private final static Object lock = new Object();
  private final AuthServer server;


  public ServerAccountModel() throws IOException {
    server = new AuthClient();
  }


  @Override public User validate(LoginMessage loginMessage) throws IOException
  {
    return server.validate(loginMessage);
  }

  @Override public boolean register(User user) throws IOException
  {
 return server.register(user);
  }

  @Override public boolean checkEmail(String message) throws IOException
  {
    return server.checkEmail(message);
  }

  @Override public boolean checkUserName(String message) throws IOException
  {
    return server.checkUserName(message);
  }

  public static ServerAccountModel getInstance()
  {
    if (instance == null)
    {
      synchronized (lock)
      {
        if (instance == null)
        {
          try
          {
            instance = new ServerAccountModel();
          }
          catch (Exception e)
          {
            e.printStackTrace();
          }
        }
      }
    }
    return instance;
  }

  @Override public boolean updateFirstName(long id, String firstname)
      throws IOException
  {
   return server.updateFirstName(id,firstname);

  }

  @Override public boolean updateLastName(long id, String lastname)
      throws IOException
  {

   return server.updateLastName(id,lastname);
  }

  @Override public boolean updateUsername(long id, String username)
      throws IOException
  {

   return server.updateUserName(id,username);
  }

  @Override public boolean updateEmail(long id, String email) throws IOException
  {

   return server.updateEmail(id,email);
  }

  @Override public boolean updatePassword(long id, String password)
      throws IOException
  {

  return   server.updatePassword(id,password);
  }
}