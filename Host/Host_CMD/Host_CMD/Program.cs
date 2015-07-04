﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Host_CMD
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
        static void Main(string[] args)
        {
           
                    //---listen at the specified IP and port no.---
                    IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                    TcpListener listener = new TcpListener(localAdd, PORT_NO);
                    Console.WriteLine("Listening...");
                    listener.Start();

                    for (; ; )
                    {
                        try
                        {
                    //---incoming client connected---
                    TcpClient client = listener.AcceptTcpClient();

                    //---get the incoming data through a network stream---
                    NetworkStream nwStream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    //---read incoming stream---
                    int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received : " + dataReceived);

                    //---write back the text to the client---
                    //      Console.WriteLine("Sending back : " + dataReceived);
                    //     nwStream.Write(buffer, 0, bytesRead);
                    client.Close();
                    //    listener.Stop();
                    
                }
                catch (Exception ex)
                {

                }
                       
            }
                    Console.ReadLine();
        }
    }
}
