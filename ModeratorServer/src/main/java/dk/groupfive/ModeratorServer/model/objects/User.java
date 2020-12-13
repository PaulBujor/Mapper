package dk.groupfive.ModeratorServer.model.objects;

import java.util.ArrayList;

public class User {
    private long id;
    private String email;
    private String username;
    private String password;
    private String firstName;
    private String lastName;
    private int auth;
    //0 banned
    //1 regular user
    //2 moderator
    //3 admin
    private ArrayList<Place> savedPlaces;


    public User() {
    }

    public User(long id, String email, String username, String password, String firstName, String lastName, int auth) {
        this.id = id;
        this.email = email;
        this.username = username;
        this.password = password;
        this.firstName = firstName;
        this.lastName = lastName;
        this.auth = auth;
        savedPlaces = new ArrayList<Place>();
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public int getAuth() {
        return auth;
    }

    public void setAuth(int auth) {
        this.auth = auth;
    }

    public ArrayList<Place> getSavedPlaces() {
        return savedPlaces;
    }

    public void setSavedPlaces(ArrayList<Place> savedPlaces) {
        this.savedPlaces = savedPlaces;
    }
}
