package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;

public interface AuthServer
{
  User validate(LoginMessage loginMessage) throws IOException;
  void register(User user) throws IOException;


}
