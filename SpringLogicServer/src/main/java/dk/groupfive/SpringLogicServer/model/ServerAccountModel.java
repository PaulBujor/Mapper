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

  @Override public void register(User user) throws IOException
  {
server.register(user);
  }

  @Override public String checkEmail(String message) throws IOException
  {
    return server.checkEmail(message);
  }

  @Override public String checkUserName(String message) throws IOException
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
}