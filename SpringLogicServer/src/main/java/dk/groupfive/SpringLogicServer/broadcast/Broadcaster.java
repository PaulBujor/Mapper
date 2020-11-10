package dk.groupfive.SpringLogicServer.broadcast;

import com.google.gson.Gson;
import dk.groupfive.SpringLogicServer.model.tasks.PlaceTask;

import java.io.IOException;
import java.net.*;
import java.util.ArrayList;

public class Broadcaster {
    private DatagramSocket socket;
    private ArrayList<String> connectedIPs;
    private boolean running;
    private byte[] buffer = new byte[512];
    private Gson gson;

    public Broadcaster() {
        gson = new Gson();
        connectedIPs = new ArrayList<String>();
        try {
            socket = new DatagramSocket(7000);
        } catch (SocketException e) {
            e.printStackTrace();
        }
    }

    public void sendTask(PlaceTask task) {
        buffer = gson.toJson(task).getBytes();
        DatagramPacket packet = new DatagramPacket(buffer, buffer.length);
        packet.setPort(15630);
        for (String ip : connectedIPs) {
            try {
                packet.setAddress(InetAddress.getByName(ip));
                socket.send(packet);
            } catch (UnknownHostException e) {
                e.printStackTrace();
                unsubscribe(ip);
            } catch (IOException e) {
                System.out.println("packet not sent");
                e.printStackTrace();
            }
        }
    }

    public void subscribe(String ip) {
        if (!connectedIPs.contains(ip))
            connectedIPs.add(ip);
        System.out.println(connectedIPs);
    }

    public void unsubscribe(String ip) {
        connectedIPs.remove(ip);
    }


}
