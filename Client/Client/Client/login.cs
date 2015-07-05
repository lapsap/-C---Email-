using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string toSend = "1!@#$%" + tb_user.Text+"!@#$%"+tb_pass.Text;
            try
            {
              /* Client.HttpSend.httpSend(toSend);
                string temp = Client.HttpSend.httpRead();
                MessageBox.Show(temp);
              */
                  MessageBox.Show(Client.HttpSend.sendAndRead(toSend));
            }
            catch
            {
                MessageBox.Show("Server offline");
            }
        }
    }
}
