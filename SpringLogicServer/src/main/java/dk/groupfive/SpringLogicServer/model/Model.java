package dk.groupfive.SpringLogicServer.model;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.network.AuthNetwork;
import dk.groupfive.SpringLogicServer.network.PlaceNetwork;
import dk.groupfive.SpringLogicServer.network.ReportNetwork;

public interface Model extends PlaceNetwork, ReportNetwork
{
}
