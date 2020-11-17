package dk.groupfive.SpringLogicServer;

import dk.groupfive.SpringLogicServer.model.ServerModel;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class SpringLogicServerApplication {
    public static void main(String[] args) {
        SpringApplication.run(SpringLogicServerApplication.class, args);
        // initializez the model with connections and everything
        ServerModel.getInstance();
    }
}
