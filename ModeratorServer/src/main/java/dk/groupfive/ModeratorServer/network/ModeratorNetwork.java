package dk.groupfive.ModeratorServer.network;

import dk.groupfive.ModeratorServer.model.objects.Report;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;

public interface ModeratorNetwork {
    List<Report> getReports();

    Report getReport(long id);

    public void resolveReport(String action, String id);
}
