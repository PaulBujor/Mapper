package dk.groupfive.ModeratorServer.model.objects;

public class User {
    private String username;
    private int auth;

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
}
