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
    public partial class Login_add : UserControl
    {
        public Form2 begin;

        public Login_add()
        {
            InitializeComponent();
            //begin = parent;
        }

        private void view_Click(object sender, EventArgs e)
        {
            sataTextBox1.PasswordChar = true;
            view.Visible = false;
            hide.Visible = true;
        }

        private void hide_Click(object sender, EventArgs e)
        {
            sataTextBox1.PasswordChar = false; // Hiện mật khẩu
            hide.Visible = false;
            view.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            begin.Signup_add_load();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Cafe"] == null)
            {
                Cafe cafeForm = new Cafe();
                cafeForm.Show();
                this.Hide();    
            }
        }
    }
}
