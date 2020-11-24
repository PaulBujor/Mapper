using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace DataServer.Handlers
{
	class AccountHandler : IHandler
	{

        private TcpClient client;
        private Model model;

        private StreamWriter writer;
        private StreamReader reader;

        private bool clientConnected;

        public AccountHandler(TcpClient client, Model model)
        {
            this.client = client;
            this.model = model;

            NetworkStream stream = client.GetStream();
            writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            reader = new StreamReader(stream, Encoding.ASCII);

        }
        public void Start()
		{
            clientConnected = true;
            string request = null;

            //todo security protocol for connetion

            // Loop to receive all the data sent by the client.
            do
            {
                try
                {
                    request = reader.ReadLine();
                    Console.WriteLine("Received: {0}", request);

                    ProcessClientRequest(request);
                }
                catch (System.IO.IOException e)
                {
                    clientConnected = false;
                }

            } while (clientConnected);

            // Shutdown and end connection
            client.Close();
        }

        private void ProcessClientRequest(string request)
        {
            switch (request)
            {
                case "login":
                    break;
                case "register":
                    break;
                default:
                    Console.WriteLine("Default was called");
                    break;
            }
        }
    }
}
