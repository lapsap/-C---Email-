using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public partial class index : Form
    {
      

        public index()
        {
            InitializeComponent();
        }


        private void btn_sendMail_Click(object sender, EventArgs e)
        {
            Send_Mail sendForm = new Send_Mail();
            sendForm.Show();
        }
    }
}
