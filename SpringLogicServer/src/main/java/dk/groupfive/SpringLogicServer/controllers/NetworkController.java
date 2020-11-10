package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.ServerModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpServletRequest;

@RestController
public class NetworkController {
    @Autowired
    public NetworkController() {

    }

    @GetMapping(value = "/subscribe")
    @ResponseStatus(HttpStatus.ACCEPTED)
    public void subscribe(HttpServletRequest request) {
        String ip = request.getRemoteAddr();
        System.out.println(ip);
        ServerModel.getInstance().subscribe(ip);
    }
}
