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
using MangageCoffee.UICoffee.Customer;
using MangageCoffee.UICoffee.Untils;

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
                Notice_2 notice_2 = new Notice_2();
                notice_2.ShowDialog();  
                return;
            }

            var user = userBLL.Login(username, password);
            if (user != null)
            {
                userBLL.SetLoginStatus(username);
                Mess mess = new Mess();
                mess.ShowDialog();
                if (mess.Proceed)
                {
                    if (user.Role == "Admin")
                    {
                        Cafe cafeForm = new Cafe();
                        cafeForm.Show();
                        cafeForm.FormClosed += (s, args) => this.Show();
                        this.Hide();
                    }
                    else if (user.Role == "Customer")
                    {
                        Customer1 customerForm = new Customer1();
                        customerForm.Show();
                        customerForm.FormClosed += (s, args) => this.Show();
                        this.Hide();
                    }
                }
            }

            else
            {
                Notice mess = new Notice("Wrong username or password!");
                mess.ShowDialog();
            }

            txtUsername.Texts = string.Empty;
            txtPassword.Texts = string.Empty;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            exit?.Invoke(this, EventArgs.Empty);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            begin.Signup_add_load();
        }
    }
}
