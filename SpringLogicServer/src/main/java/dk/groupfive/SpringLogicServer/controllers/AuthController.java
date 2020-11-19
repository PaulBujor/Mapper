package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.AccountModel;
import dk.groupfive.SpringLogicServer.model.ServerAccountModel;
import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;
import dk.groupfive.SpringLogicServer.network.AuthNetwork;
import dk.groupfive.SpringLogicServer.remote.Server;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.HttpClientErrorException;

@RestController
public class AuthController
{

  private AccountModel accountModel;

  @Autowired
  public AuthController(){
accountModel = ServerAccountModel.getInstance();
  }


  @PostMapping(value = "/auth")
   public User validate(@RequestBody LoginMessage loginMessage)
  {

       return accountModel.validate(loginMessage.username,loginMessage.password);
       
  }

  @PostMapping(value = "/reg")
  public User register()
  {
    return accountModel.register();
  }
}
