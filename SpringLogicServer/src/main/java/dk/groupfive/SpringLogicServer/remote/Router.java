package dk.groupfive.SpringLogicServer.remote;

import dk.groupfive.SpringLogicServer.model.objects.*;

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
    public Review addPlaceReview(long id, Review reviewItem) throws IOException {
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
    public void addReportUser(Report<UserData> report){
        reportClient.addReportUser(report);
    }

    @Override
    public void addReportReview(Report<Review> report){
        reportClient.addReportReview(report);
    }

    @Override
    public void addSavedPlace(long userId, long placeId) {
        placeClient.addSavedPlace(userId,placeId);
    }

    @Override
    public void removeSavedPlace(long userId, long placeId) {
        placeClient.removeSavedPlace(userId,placeId);
    }
}
