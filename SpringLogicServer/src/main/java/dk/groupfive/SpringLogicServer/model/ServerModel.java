package dk.groupfive.SpringLogicServer.model;

import dk.groupfive.SpringLogicServer.local.Cache;
import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.remote.Server;
import dk.groupfive.SpringLogicServer.remote.Client;

import java.io.IOException;
import java.util.List;

//todo implement server task queue and thread pool resolvers
public class ServerModel implements Model {
    //TODO TCP connection to tier 3
    private static volatile ServerModel instance;
    private final static Object lock = new Object();

    private final Cache cache;
    private final Server server;


    private ServerModel() throws IOException {
        cache = new Cache();
        server = new Client();
        new Thread(() -> {
            try {
                cache.load(server.getAllPlaces());
            } catch (IOException e) {
                e.printStackTrace();
            }
        }).start();
    }

    public static ServerModel getInstance() {
        if(instance == null) {
            synchronized (lock) {
                if (instance == null) {
                    try {
                        instance = new ServerModel();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
        return instance;
    }

    @Override
    public List<Place> getAllPlaces() {
        return cache.getAllPlaces();
    }

    @Override
    public Place getPlaceByID(long id) {
        return cache.getPlaceByID(id);
    }

    @Override
    public void addPlace(Place place) {
        place = server.addPlace(place);
        cache.addPlace(place);
        //todo send to broadcaster

    }

    @Override
    public void updatePlace(Place place) {
        cache.updatePlace(place);
    }

    @Override
    public void deletePlace(long id) {

    }
}
