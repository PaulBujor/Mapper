package dk.groupfive.ModeratorServer.model;

import dk.groupfive.ModeratorServer.local.Cache;
import dk.groupfive.ModeratorServer.model.objects.Report;

import java.io.IOException;
import java.util.List;

public class ModeratorModel implements Model{
    private static volatile ModeratorModel instance;
    private final static Object lock = new Object();

    private Cache cache;

    private ModeratorModel() throws IOException {
        cache = new Cache();
        cache.loadReports(null);//todo load with reports from the server -- put in new thread that reloads every x amount of time
    }

    public static Model getInstance() {
        if (instance == null) {
            synchronized (lock) {
                if (instance == null) {
                    try {
                        instance = new ModeratorModel();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
        return instance;
    }

    @Override
    public List<Report> getReports() {
        return cache.getReports();
    }

    @Override
    public Report getReport(long id) {
        return cache.getReport(id);
    }

    //todo decide on what the actions do:
    // removing -> removes from database
    // OR
    // removing -> moves/adds to another table so that data is nor removed, but made unavailable
    @Override
    public void resolveReport(String action, String id) {
        switch (action) {
            default:
                System.out.println("Action not implemented!");
        }
    }
}
