package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.AccountModel;
import dk.groupfive.SpringLogicServer.model.ServerAccountModel;
import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;

@RestController
public class AuthController
{

  private AccountModel accountModel;

  @Autowired
  public AuthController(){
accountModel = ServerAccountModel.getInstance();
  }


  @PostMapping(value = "/auth")
  @ResponseBody
   public User validate(@RequestBody LoginMessage loginMessage)
  {
    System.out.println("Test");
    System.out.println(loginMessage.password);
    System.out.println(loginMessage.username);

   return new User("tester","teest",2);
      /* return accountModel.validate(loginMessage);*/

  }

  @PostMapping(value = "/reg")
  public void register(@RequestBody User user)
  {
    try
    {
      accountModel.register(user);
    }
    catch (IOException e){

    }
  }
}
