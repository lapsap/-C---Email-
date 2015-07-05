using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Host
{
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
           MessageBox.Show(Host.index.makeUser(tb_name.Text, tb_user.Text, tb_pass.Text) );
           tb_pass.Text = "";
           tb_name.Text = "";
           tb_user.Text = "";
        }
    }
}
