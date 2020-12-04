package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Report;
import dk.groupfive.SpringLogicServer.model.objects.ReviewItem;
import dk.groupfive.SpringLogicServer.model.objects.User;

import java.io.IOException;
import java.util.List;

public class Router implements Server{

    private PlaceClient placeClient;
    private ReportClient reportClient;

    public Router() throws IOException {
        placeClient = new PlaceClient();
        reportClient = new ReportClient();
    }


    @Override
    public List<Place> getAllPlaces() throws IOException {
        return placeClient.getAllPlaces();
    }

    @Override
    public Place getPlaceByID(long id) {
        return placeClient.getPlaceByID(id);
    }

    @Override
    public Place addPlace(Place place) throws IOException {
        return placeClient.addPlace(place);
    }

    @Override
    public ReviewItem addPlaceReview(long id, ReviewItem reviewItem) throws IOException {
        return placeClient.addPlaceReview(id, reviewItem);
    }

    @Override
    public void updatePlace(Place place) {
        placeClient.updatePlace(place);
    }

    @Override
    public void deletePlace(long id) {
        placeClient.deletePlace(id);
    }

    @Override
    public void addReportPlace(Report<Place> report){
        reportClient.addReportPlace(report);
    }

    @Override
    public void addReportUser(Report<User> report){
        reportClient.addReportUser(report);
    }

    @Override
    public void addReportReview(Report<ReviewItem> report){
        reportClient.addReportReview(report);
    }
}
