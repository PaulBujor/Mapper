package dk.groupfive.SpringLogicServer.controllers;

import dk.groupfive.SpringLogicServer.model.Model;
import dk.groupfive.SpringLogicServer.model.objects.*;
import dk.groupfive.SpringLogicServer.queue.ServerQueue;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;

@RestController
public class ReportController {

    private Model model;

    @Autowired
    public ReportController() {
        model = ServerQueue.getInstance();
    }

    @PostMapping(value = "/reports/places")
    @ResponseStatus(HttpStatus.CREATED)
    public void reportPlace(@RequestBody Report<Place> report) {
        model.addReportPlace(report);
    }

    @PostMapping(value = "/reports/users")
    @ResponseStatus(HttpStatus.CREATED)
    public void reportUser(@RequestBody Report<UserData> report) {
        model.addReportUser(report);
    }

    @PostMapping(value = "/reports/reviews")
    @ResponseStatus(HttpStatus.CREATED)
    public void reportReview(@RequestBody Report<Review> report) {
        model.addReportReview(report);
    }

}
