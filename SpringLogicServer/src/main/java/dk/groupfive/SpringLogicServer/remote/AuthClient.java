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

public class AuthClient implements AuthServer {

    final String HOST = "localhost";
    final int PORT = 7020;
    private Socket socket;
    private PrintWriter out;
    private BufferedReader in;
    private Gson gson;


    public AuthClient() throws IOException {
        socket = new Socket(HOST, PORT);
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new PrintWriter(socket.getOutputStream(), true);
        gson = new Gson();
    }


    @Override
    public synchronized User validate(LoginMessage loginMessage) throws IOException {
        out.println("login");
        out.println(loginMessage.username);
        out.println(loginMessage.password);
        String response = in.readLine();
        User user = gson.fromJson(response, User.class);
        return user;
    }


    //True means that task was successful
    @Override
    public synchronized boolean register(User user) throws IOException {

        out.println("register");
        String send = gson.toJson(user);
        out.println(send);
        String response = in.readLine();
        if (response.contains("true")) {
            return true;
        } else return false;

    }

    @Override
    public synchronized boolean checkEmail(String message) throws IOException {
        out.println("checkEmail");
        out.println(message);
        String response = in.readLine();
        if (response.contains("true")) {
            return true;
        } else return false;
    }

    //TODO have t3 return a boolean
    @Override
    public synchronized boolean checkUserName(String message) throws IOException {
        out.println("checkUserName");
        out.println(message);
        String response = in.readLine();
        if (response.contains("true")) {
            return true;
        } else return false;
    }

    @Override
    public synchronized boolean updateFirstName(long id, String firstname)
            throws IOException {
        out.println("updateFirstName");

        out.println(id);
        out.println(firstname);
        String response = in.readLine();

        if (response.contains("true")) {
            return true;
        } else return false;
    }

    @Override
    public synchronized boolean updateLastName(long id, String lastname)
            throws IOException {
        out.println("updateLastName");
        out.println(id);
        out.println(lastname);
        String response = in.readLine();

        if (response.contains("true")) {
            return true;
        } else return false;
    }

    @Override
    public synchronized boolean updateUserName(long id, String username)
            throws IOException {
        out.println("updateUserName");
        out.println(id);
        out.println(username);
        String response = in.readLine();
        if (response.contains("true")) {
            return true;
        } else return false;
    }

    @Override
    public synchronized boolean updateEmail(long id, String email) throws IOException {
        out.println("updateEmail");
        out.println(id);
        out.println(email);
        String response = in.readLine();
        if (response.contains("true")) {
            return true;
        } else return false;
    }

    @Override
    public synchronized boolean updatePassword(long id, String password)
            throws IOException {
        out.println("updatePassword");
        out.println(id);
        out.println(password);
        String response = in.readLine();
        if (response.contains("true")) {
            return true;
        } else return false;
    }
}
