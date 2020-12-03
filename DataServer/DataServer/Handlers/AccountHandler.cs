﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Schema;
using DataServer.Models;

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
                    Login();
                    break;
                case "register":
                    Register();
                    break;
                case "checkEmail":
                    CheckEmail();
                    break;
                case "checkUserName":
                    CheckUsername();
                    break;
                case "updateFirstName":
                    UpdateFirstname();
                    break;
                case "updateLastName":
                    UpdateLastName();
                    break;
                case "updateUserName":
                    UpdateUserName();
                    break;
                case "updateEmail":
                    UpdateEmail();
                    break;
                case "updatePassword":
                    UpdatePassword();
                    break;
                default:
                    Console.WriteLine("Default was called");
                    break;
            }
        }

        
        private async Task Login()
        {
            string receivedUserName = reader.ReadLine();
            string receivedPassword = reader.ReadLine();
            
              User tmpUser =  await model.Login(receivedUserName, receivedPassword);
             string tmpUserSerialize = JsonSerializer.Serialize(tmpUser);
              writer.WriteLine(tmpUserSerialize);
              
        }

        private void Register()
        {
            string receive = reader.ReadLine();
            User user = JsonSerializer.Deserialize<User>(receive);
            try
            {
                model.Register(user);
                writer.WriteLine("true");
            }
            catch (Exception e)
            {
                writer.WriteLine("false");
            }
        }

        private void CheckUsername()
        {

            string receivedUserName = reader.ReadLine();
            
            try
            {
                model.CheckUsername(receivedUserName);
                writer.WriteLine("true");
            }
            catch (Exception e)
            {
                writer.WriteLine("false");
            }
            
        }

        private void CheckEmail()
        {
            string receivedEmail = reader.ReadLine();
            try
            {

                model.CheckEmail(receivedEmail);
                writer.WriteLine("true");
            }
            catch (Exception e)
            {
                writer.WriteLine("false");
            }
            
        }

        private void UpdateFirstname()
        {
            long id = long.Parse(reader.ReadLine());
            string receivedName = reader.ReadLine();
            try
            {
                model.UpdateFirstName(id,receivedName);
                writer.WriteLine("true");
            }
            catch (Exception e)
            {
                writer.WriteLine("false");
            }
            
        }

        private void UpdateLastName()
        {
            long id = long.Parse(reader.ReadLine());
            string receivedLastName = reader.ReadLine();
            try
            {
                model.UpdateLastName(id,receivedLastName);
                writer.WriteLine("true");
            }
            catch (Exception e)
            {
                writer.WriteLine("false");
            }
        }

        private void UpdateUserName()
        {
            
            long id = long.Parse(reader.ReadLine());
            string receivedUserName = reader.ReadLine();
            
            try
            {
                model.UpdateUsername(id,receivedUserName);
                writer.WriteLine("true");
            }
            catch (Exception e)
            {
                writer.WriteLine("false");
            }
        }

        private void UpdateEmail()
        {
            long id = long.Parse(reader.ReadLine());
            string receivedEmail = reader.ReadLine();
            try
            {
                model.UpdateEmail(id,receivedEmail);
                writer.WriteLine("true");
            }
            catch (Exception e)
            {
                writer.WriteLine("false");
            }
        }

        private void UpdatePassword()
        {
            long id = long.Parse(reader.ReadLine());
            string receivedPassword = reader.ReadLine();
            try
            {
                model.UpdatePassword(id,receivedPassword); 
                writer.WriteLine("true");
            }
            catch (Exception e)
            {
                writer.WriteLine("false");
            }

        }
    }
}
