package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.ServerAccountModel;
import dk.groupfive.SpringLogicServer.model.objects.User;
import dk.groupfive.SpringLogicServer.network.AuthNetwork;
import dk.groupfive.SpringLogicServer.remote.Server;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class AuthController
{


  @Autowired
  public AuthController(){

  }

  //TODO havent tested but would be too good to be true
  @PostMapping(value = "/auth")
   public User validate(@RequestBody String[] message)
  {
    String username = message[0];
    String password = message[1];

   return ServerAccountModel.getInstance().validate(username,password);
  }

  @PostMapping(value = "/reg")
  public User register()
  {
    return ServerAccountModel.getInstance().register();
  }
}
