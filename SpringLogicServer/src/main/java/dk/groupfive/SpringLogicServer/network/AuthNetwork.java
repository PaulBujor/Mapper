package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;

public interface AuthNetwork
{

  User validate(LoginMessage loginMessage) throws IOException;
  User register();


}
