﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class AdminForm : Form
    {
        public AdminForm(string name, string pass)
        {
            InitializeComponent();
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
