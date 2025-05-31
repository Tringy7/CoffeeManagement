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
using MangageCoffee.UICoffee.Untils;

namespace MangageCoffee
{
    public partial class Signup_add : UserControl
    {
        public Form2 begin;
        public event EventHandler exit;
        UserBLL userBLL = new UserBLL();

        public Signup_add()
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


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            begin.Login_add_load();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            exit?.Invoke(this, EventArgs.Empty); 
        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Texts.Trim();
            string password = txtPassword.Texts.Trim();
            string email = txtEmail.Texts.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Notice_2 notice_2 = new Notice_2();
                notice_2.ShowDialog();
                return;
            }

            if (userBLL.IsUsernameTaken(username))
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
                return;
            }

            UserDTO newUser = new UserDTO(username, password, email);

            if (userBLL.Register(newUser))
            {
                Notice notice = new Notice("Registration successful!");
                notice.ShowDialog();
                if (begin is Form2 form)
                {
                    form.Login_add_load();
                }
            }
            else
            {
                Notice notice = new Notice("Registration failed!");
                notice.ShowDialog();
            }
            txtUsername.Texts = string.Empty;
            txtPassword.Texts = string.Empty;
            txtEmail.Texts = string.Empty;
        }
    }
}
