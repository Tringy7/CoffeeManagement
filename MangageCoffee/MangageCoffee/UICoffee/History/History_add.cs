﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee.History
{
    public partial class History_add : UserControl
    {
        public History_add()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            history_historyform1.BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            history_historyform1.SendToBack();
        }
    }
}
