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

namespace Client
{
    public partial class Send_Mail : Form
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        public Send_Mail()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = "<<ip>>" + LocalIPAddress();
                string to = "<<to>>" + tb_to.Text;
                string subject = "<<sub>>" + tb_subject.Text;
                string msg = "<<msg>>" + tb_msg.Text;

                string toSend = ip + to + subject + msg;

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
                MessageBox.Show("Mail Sent !");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errorrr");
                // bug logger~~
            }
        }

 

        public static string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

    }
}
