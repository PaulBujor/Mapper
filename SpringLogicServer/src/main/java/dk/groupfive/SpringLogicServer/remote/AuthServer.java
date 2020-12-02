package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;

public interface AuthServer
{
  User validate(LoginMessage loginMessage) throws IOException;
  boolean register(User user) throws IOException;
  boolean checkEmail(String message) throws IOException;
  boolean checkUserName(String message) throws IOException;
  boolean updateFirstName(long id, String firstname) throws IOException;
  boolean updateLastName(long id, String lastname) throws  IOException;
  boolean updateUserName(long id, String username) throws IOException;
  boolean updateEmail(long id, String email) throws IOException;
  boolean updatePassword(long id, String password) throws IOException;

}
