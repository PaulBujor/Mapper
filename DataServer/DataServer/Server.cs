using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DataServer
{
    class Server
    {
        private Int32 PORT = 6969;
        TcpListener server;
        Model model;

        public Server()
        {
            model = new Model();
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, PORT);

                // Start listening for client requests.
                server.Start();
                StartListening();

            }
            catch (Exception e)
            { }
        }

        public void StartListening()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                
                ClientHandler clientHandler = new ClientHandler(client, model);
                Thread thread = new Thread(clientHandler.Start);
                thread.Start();

            }
        }


    }
}
