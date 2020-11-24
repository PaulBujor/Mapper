package dk.groupfive.ModeratorServer.model.objects;

public class User {
    private long id;
    private String email;
    private String username;
    private String password;
    private int auth;


    //0 banned
    //1 regular user
    //2 moderator
    //3 admin


}
