package dk.groupfive.ModeratorServer.model.objects;

public class User {
    private String username;
    private String password;
    private int auth;
    //0 banned
    //1 regular user
    //2 moderator
    //3 admin

    public User(String username, int auth) {
        this.username = username;
        this.auth = auth;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public int getAuth() {
        return auth;
    }

    public void setAuth(int auth) {
        this.auth = auth;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
