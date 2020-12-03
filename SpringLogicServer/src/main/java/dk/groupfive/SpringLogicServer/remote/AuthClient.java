package dk.groupfive.SpringLogicServer.remote;

import com.google.gson.Gson;
import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;

import javax.sound.sampled.Port;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class AuthClient implements AuthServer
{

  final String HOST = "localhost";
  final int PORT = 7020;
  private Socket socket;
  private PrintWriter out;
  private BufferedReader in;
  private Gson gson;


  public AuthClient() throws  IOException{
    socket = new Socket(HOST, PORT);
    in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
    out = new PrintWriter(socket.getOutputStream(),true);
    gson = new Gson();
  }





  @Override public User validate(LoginMessage loginMessage) throws IOException
  {
    out.println("authenticateUser");
    String send = gson.toJson(loginMessage);
    out.println(send);
    String response = in.readLine();
    User user = gson.fromJson(response,User.class);
    return user;
  }

  //TODO have t3 return a boolean
  //True means that task was successful
  @Override public boolean register (User user) throws IOException
  {

    out.println("register");
    String send = gson.toJson(user);
    out.println(send);
    String response = in.readLine();
    if(true)
    {
     return true;
    }else return false;

  }

  @Override public boolean checkEmail(String message) throws IOException
  {
    out.println("checkEmail");
    String send = gson.toJson(message);
    out.println(send);
    String response = in.readLine();
    if(true){
      return true;
    }else return false;
  }

  //TODO have t3 return a boolean
  @Override public boolean checkUserName(String message) throws IOException
  {
    out.println("checkUserName");
    String send = gson.toJson(message);
    out.println(send);
    String response = in.readLine();
    if(true){
      return true;
    }else return false;
  }

  @Override public synchronized boolean updateFirstName(long id, String firstname)
      throws IOException
  {
      out.println("updateFirstName");

      out.println(id);
      out.println(firstname);
    String response = in.readLine();

    if(true){
      return true;
    }else return false;
  }

  @Override public synchronized boolean updateLastName(long id, String lastname)
      throws IOException
  {
    out.println("updateLastName");
    out.println(id);
    out.println(lastname);
    String response = in.readLine();

    if(true){
      return true;
    }else return false;
  }

  @Override public synchronized boolean updateUserName(long id, String username)
      throws IOException
  {
    out.println("updateUserName");
    out.println(id);
    out.println(username);
    String response = in.readLine();
    if(true){
      return true;
    }else return false;
  }

  @Override public synchronized boolean updateEmail(long id, String email) throws IOException
  {
    out.println("updateEmail");
    out.println(id);
    out.println(email);
    String response = in.readLine();
    if(true){
      return true;
    }else return false;
  }

  @Override public synchronized boolean updatePassword(long id, String password)
      throws IOException
  {
    out.println("updatePassword");
    out.println(id);
    out.println(password);
    String response = in.readLine();
    if(true){
      return true;
    }else return false;
  }
}
