package dk.groupfive.SpringLogicServer.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpServletRequest;

@RestController
public class NetworkController {
    @Autowired
    public NetworkController() {

    }

    @PutMapping(value = "/subscribe")
    @ResponseStatus(HttpStatus.ACCEPTED)
    public void subscribe(HttpServletRequest request) {
        System.out.println(request.getRemoteAddr());
        //todo subscribe to broadcaster
    }
}
