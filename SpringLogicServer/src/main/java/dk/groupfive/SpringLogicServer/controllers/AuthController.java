package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.AccountModel;
import dk.groupfive.SpringLogicServer.model.ServerAccountModel;
import dk.groupfive.SpringLogicServer.model.objects.LoginMessage;
import dk.groupfive.SpringLogicServer.model.objects.Message;
import dk.groupfive.SpringLogicServer.model.objects.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

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

   return new User("tester","teest","tester@dk.dk",2,"bob","gob",200);
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
      return new ResponseEntity(HttpStatus.CONFLICT);
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
      return new ResponseEntity(HttpStatus.CONFLICT);
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
  @PatchMapping("/auth/users/{id}/firstname")
  public ResponseEntity updateFirstName(@PathVariable("id") long id,@RequestBody String firstname){

    System.out.println("--------------------------------");
    System.out.println("Update first name received");

    try
    {
      boolean value = accountModel.updateFirstName(id, firstname);
      if(value){
      return new ResponseEntity(HttpStatus.OK);}
    }
    catch (Exception e){
      e.printStackTrace();

    }
    return new ResponseEntity(HttpStatus.INTERNAL_SERVER_ERROR);
  }


  @PatchMapping("/auth/users/{id}/lastname")
  public ResponseEntity updateLastName(@PathVariable("id") long id,@RequestBody String lastname){

    System.out.println("--------------------------------");
    System.out.println("Update last name received");

    try{
    boolean value=  accountModel.updateLastName(id,lastname);
    if(value){
      return new ResponseEntity(HttpStatus.OK);}
    }
    catch (Exception e){
      e.printStackTrace();

    }
    return new ResponseEntity(HttpStatus.INTERNAL_SERVER_ERROR);
  }


  @PatchMapping("/auth/users/{id}/username")
  public ResponseEntity updateUsername(@PathVariable("id") long id,@RequestBody String username){

    System.out.println("--------------------------------");
    System.out.println("Update  username received:");

    try{
     boolean value = accountModel.updateUsername(id,username);
     if(value)
     {
       return new ResponseEntity(HttpStatus.OK);
     }
    }
    catch (Exception e){
      e.printStackTrace();
    }
    return new ResponseEntity(HttpStatus.INTERNAL_SERVER_ERROR);
  }

  @PatchMapping("/auth/users/{id}/email")
  public ResponseEntity updateEmail(@PathVariable("id") long id,@RequestBody String email) {

    System.out.println("--------------------------------");
    System.out.println("Update email  received");

    try{
    boolean value=  accountModel.updateEmail(id,email);
    if(value){
      return new ResponseEntity(HttpStatus.OK);}
    }
    catch (Exception e){
      e.printStackTrace();
    }
    return new ResponseEntity(HttpStatus.INTERNAL_SERVER_ERROR);
  }

  @PatchMapping("/auth/users/{id}/password")
  public ResponseEntity updatePassword(@PathVariable("id") long id,@RequestBody String password){
    System.out.println("--------------------------------");
    System.out.println("Update password received");

    try{
     boolean value = accountModel.updatePassword(id,password);
     if(value){
      return new ResponseEntity(HttpStatus.OK);}
    }
    catch (Exception e){
      e.printStackTrace();
    }
    return new ResponseEntity(HttpStatus.INTERNAL_SERVER_ERROR);
  }





}
