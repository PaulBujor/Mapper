package dk.groupfive.SpringLogicServer.network;

import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;

public interface AuthNetwork
{

  User validate(LoginMessage loginMessage) throws IOException;
  void register(User user) throws IOException;
  String checkEmail(String message) throws IOException;
  String checkUserName(String message) throws IOException;



}
