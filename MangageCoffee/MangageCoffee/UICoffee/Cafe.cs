using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee
{
    public partial class Cafe : Form
    {
        public Cafe()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // <-- Đặt giữa màn hình

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home1.BringToFront();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            user_add1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            menu_add1.BringToFront();  
        }
    }
}
