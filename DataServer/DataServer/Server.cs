﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using DataServer.Handlers;
using System.Threading.Tasks;

namespace DataServer
{
	class Server
	{
		private IPAddress address;
		private int port;
		private TcpListener server;
		private Model model;

		public Server(IPAddress address, int port, Model model)
		{
			this.model = model;
			this.address = address;
			this.port = port;
		}

		public void StartListening()
		{
			try
			{
				// TcpListener server = new TcpListener(port);
				server = new TcpListener(address, port);

				// Start listening for client requests.
				server.Start();
				while (true)
				{
					TcpClient client = server.AcceptTcpClient();

					//start new handler depending on the incoming port connection (on new thread)
					IHandler handler;
					switch (port)
					{
						case 7010:
							handler = new ModeratorHandler(client, model);
							break;
						case 7020:
							handler = new AccountHandler(client, model);
							break;
						case 7030:
							handler = new ReportingHandler(client, model);
							break;
						default:
							handler = new ClientHandler(client, model);
							break;
					}
					Thread thread = new Thread(h => handler.Start());
					thread.Start();

				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}


	}
}
