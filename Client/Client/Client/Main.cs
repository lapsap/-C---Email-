﻿using System;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Compose_Click(object sender, EventArgs e)
        {
            Send_Mail formSend = new Send_Mail();
            formSend.Show();
        }

     
    }
}
