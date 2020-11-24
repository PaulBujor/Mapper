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

  @Override public void register (User user) throws IOException
  {

    out.println("register");
    String send = gson.toJson(user);
    out.println(send);

  }
}
