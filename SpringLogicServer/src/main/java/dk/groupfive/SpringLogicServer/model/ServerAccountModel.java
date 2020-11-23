package dk.groupfive.SpringLogicServer.model;

import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;
import dk.groupfive.SpringLogicServer.remote.Client;
import dk.groupfive.SpringLogicServer.remote.Server;

import java.io.IOException;

public class ServerAccountModel implements AccountModel
{

  private static ServerAccountModel instance;
  private final static Object lock = new Object();
  private final Server server;


  public ServerAccountModel() throws IOException {
    server = new Client();
  }


  @Override public User validate(LoginMessage loginMessage) throws IOException
  {
    return server.validate(loginMessage);
  }

  @Override public User register()
  {
    return null;
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