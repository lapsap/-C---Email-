using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class HttpSend
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        public static void httpSend(string toSend)
        {
            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(toSend);


            //---send the text---
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            //     byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            //       int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            //         Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            //         Console.ReadLine();
            client.Close();
        }
        //
        public static string httpRead()
        {
            string result = "";

            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
           //--read back the text---
                 byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                   int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                     result = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);           
            client.Close();

            return result;
        }
        //
        public static string sendAndRead(string toSend)
        {
            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(toSend);


            //---send the text---
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
                 byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                   int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            client.Close();
            return Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
        }


    }
}
