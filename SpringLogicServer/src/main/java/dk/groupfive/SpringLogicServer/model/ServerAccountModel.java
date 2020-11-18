package dk.groupfive.SpringLogicServer.model;

import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;

public class ServerAccountModel implements AccountModel
{

  private static ServerAccountModel instance;
  private final static Object lock = new Object();

  @Override public User validate(String username, String password)
  {
    return null;
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