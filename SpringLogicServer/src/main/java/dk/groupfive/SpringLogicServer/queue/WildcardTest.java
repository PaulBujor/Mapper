package dk.groupfive.SpringLogicServer.queue;

import dk.groupfive.SpringLogicServer.model.objects.Place;
import dk.groupfive.SpringLogicServer.model.objects.Report;
import dk.groupfive.SpringLogicServer.model.objects.User;

public class WildcardTest {
    public static void main(String[] args) {
        Place place = new Place();
        Report<?> first = new Report<Place>(place);
        System.out.println(first.getReportedClass());

        User user = new User();
        first = new Report<User>(user);
        System.out.println(first.getReportedClass());
    }
}
