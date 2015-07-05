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

        private void index_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login formLogin = new login();
            formLogin.Show();
        }

      
    }
}
