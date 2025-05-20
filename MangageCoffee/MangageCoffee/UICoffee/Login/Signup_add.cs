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
    public partial class Signup_add : UserControl
    {
        public Form2 begin;
        public event EventHandler exit;


        public Signup_add()
        {
            InitializeComponent();
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


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            begin.Login_add_load();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            exit?.Invoke(this, EventArgs.Empty); // Gọi sự kiện
        }
    }
}
