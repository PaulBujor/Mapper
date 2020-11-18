package dk.groupfive.ModeratorServer.controllers;

import dk.groupfive.ModeratorServer.model.Model;
import dk.groupfive.ModeratorServer.model.ModeratorModel;
import dk.groupfive.ModeratorServer.model.objects.Report;
import dk.groupfive.ModeratorServer.network.ModeratorNetwork;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ModeratorController implements ModeratorNetwork { //todo interface
    private Model model;

    @Autowired
    public ModeratorController() {
        model = ModeratorModel.getInstance();
    }

    @GetMapping("/reports")
    public List<Report> getReports() {
        return model.getReports();
    }

    @GetMapping("/reports/{id}")
    public Report getReport(@PathVariable("id") long id) {
        return model.getReport(id);
    }

    @PostMapping("/reports/{id}")
    @ResponseStatus(HttpStatus.CREATED)
    public void resolveReport(@RequestBody String action, @PathVariable("id") String id) {
        model.resolveReport(action, id);
    }


}
