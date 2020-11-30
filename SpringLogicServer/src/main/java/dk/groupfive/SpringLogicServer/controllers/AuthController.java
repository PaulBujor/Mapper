package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.AccountModel;
import dk.groupfive.SpringLogicServer.model.ServerAccountModel;
import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.Message;
import dk.groupfive.SpringLogicServer.model.objects.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
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

   return new User("tester","teest","tester@dk.dk",2,"bob","gob");
      /* return accountModel.validate(loginMessage);*/

  }

  @PostMapping(value = "/reg")
  public void register(@RequestBody User user)
  {
  /*  try
    {
      accountModel.register(user);
    }
    catch (IOException e){

    }
    */
    System.out.println("Register received ");
  }
  @PostMapping(value = "/email")
  public ResponseEntity checkEmail(@RequestBody String message){
    System.out.println("check Email received");
    System.out.println(message);
    System.out.println("----------------------------------");

    if(message.contains("test@dk.dk")){
      return new ResponseEntity(HttpStatus.BAD_REQUEST);
    }
    System.out.println(message);
   /* try{
    return  accountModel.checkEmail(email);
    }
    catch (IOException e){
      return null;
    }*/
    return new ResponseEntity(HttpStatus.OK);
  }

  @PostMapping(value = "/uname")
  public ResponseEntity checkUserName(@RequestBody String message){
    System.out.println("check username received");
    System.out.println(message);
    if(message.contains("tester")){
      System.out.println("works");
      return new ResponseEntity(HttpStatus.BAD_REQUEST);
    }
    return new ResponseEntity(HttpStatus.OK);
 /*   try
    {
      return accountModel.checkUserName(username);
    }catch (IOException e){
      return null;
    }
*/

  }
}
