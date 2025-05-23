using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.ADO.NET.BLL;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;
using MangageCoffee.UICoffee;

namespace MangageCoffee
{
    public partial class Login_add : UserControl
    {
        public Form2 begin;
        public event EventHandler exit;
        UserBLL userBLL = new UserBLL();

        public Login_add()
        {
            InitializeComponent();
        }

        private void view_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = true;
            view.Visible = false;
            hide.Visible = true;
        }

        private void hide_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = false; 
            hide.Visible = false;
            view.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            begin.Signup_add_load();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Texts.Trim();
            string password = txtPassword.Texts.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            var user = userBLL.Login(username, password);
            if (user != null)
            {
                userBLL.SetLoginStatus(username);
                MessageBox.Show("Đăng nhập thành công");
                if (user.Role == "Admin")
                {
                    Cafe cafeForm = new Cafe();
                    cafeForm.Show();
                    cafeForm.FormClosed += (s, args) => this.Show();
                    this.Hide();
                }
                else if (user.Role == "Customer")
                {
                    Customers customerForm = new Customers();
                    customerForm.Show();
                    customerForm.FormClosed += (s, args) => this.Show();
                    this.Hide();
                }
            }

            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
            }

            txtUsername.Texts = string.Empty;
            txtPassword.Texts = string.Empty;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            exit?.Invoke(this, EventArgs.Empty);
        }
    }
}
