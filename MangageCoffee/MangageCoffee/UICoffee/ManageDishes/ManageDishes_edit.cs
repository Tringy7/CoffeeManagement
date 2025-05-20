using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee.ManageDishes
{
    public partial class ManageDishes_edit : Form
    {
        public ManageDishes_edit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // <-- Đặt giữa màn hình
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
