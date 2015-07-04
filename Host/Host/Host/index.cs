using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Host
{
    public partial class index : Form
    {
        const int PORT_NO = 5000;   //Port number to conenct
        const string SERVER_IP = "127.0.0.1";   //host ip
        //
        IPAddress localAdd = IPAddress.Parse(SERVER_IP);
        TcpListener listener;
        Thread threadClient;    //for continuesly listening for data input

        public index()
        {
            InitializeComponent();
            //
            listener = new TcpListener(localAdd, PORT_NO);  
            listener.Start();           //start the server  
            threadClient = new Thread(serverListen);    //which void should this thread be link  to 
            threadClient.Start();   //start listening for data
        }

        private void index_Load(object sender, EventArgs e)
        {
        }

        delegate void setTextCallBack(string input);    //method for outside thread to write in text field
        public void addText(string input)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                setTextCallBack d = new setTextCallBack(addText);
                this.Invoke(d, new object[] { input });
            }
            else
            {
                richTextBox1.Text += input + "\n ";
            }
        }
        public void serverListen()
        {
            while (true)
            {
                try
                {
                    //serverListen();
                    //---incoming client connected---
                    TcpClient client = listener.AcceptTcpClient();

                    //---get the incoming data through a network stream---
                    NetworkStream nwStream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    //---read incoming stream---
                    int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    //    Console.WriteLine("Received : " + dataReceived);
                    // richTextBox1.Text += dataReceived + "\n";
                    addText(dataReceived);

                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //---data to send to the server---
            string textToSend = DateTime.Now.ToString();

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            Console.WriteLine("Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
          /*  byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            Console.ReadLine();
            */client.Close();
        }

       
        private void index_FormClosed(object sender, FormClosedEventArgs e)
        {
            listener.Stop();
            threadClient.Abort();
        }
      
    }
}
