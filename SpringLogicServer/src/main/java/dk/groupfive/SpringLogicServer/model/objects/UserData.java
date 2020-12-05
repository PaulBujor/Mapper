package dk.groupfive.SpringLogicServer.model.objects;

public class UserData {
    private long userId;
    private String username;

    public UserData() {
    }

    public UserData(long userId, String username) {
        this.userId = userId;
        this.username = username;
    }

    public long getUserId() {
        return userId;
    }

    public void setUserId(long userId) {
        this.userId = userId;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
