using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee.Untils
{
    public partial class Notice : Form
    {
        public Notice(String message)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            mess.Text = message;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mess_Click(object sender, EventArgs e)
        {

        }
    }
}
