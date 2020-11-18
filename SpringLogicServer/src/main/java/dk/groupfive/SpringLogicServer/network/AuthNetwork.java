package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.User;

public interface AuthNetwork
{

  User validate(String username,String password);
  User register();


}
