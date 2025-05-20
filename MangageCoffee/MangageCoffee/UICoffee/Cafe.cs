using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.UICoffee.ManageDishes;

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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Form2"] == null)
            {
                Form2 login = new Form2();
                login.Show();
                this.Hide(); // Ẩn form hiện tại
            }
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            manage1.BringToFront();
        }
    }
}
