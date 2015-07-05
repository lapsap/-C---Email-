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
                try
                {
                    Client.HttpSend.httpSend(toSend);
                    MessageBox.Show("Mail Sent !");
                    
                }
                catch
                {
                    MessageBox.Show("ERROR! mail not sent");
                }
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
