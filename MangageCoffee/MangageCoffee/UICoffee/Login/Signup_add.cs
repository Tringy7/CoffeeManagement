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
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            if (userBLL.IsUsernameTaken(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.");
                return;
            }

            UserDTO newUser = new UserDTO(username, password, email);

            if (userBLL.Register(newUser))
            {
                MessageBox.Show("Đăng ký thành công!");
                if (begin is Form2 form)
                {
                    form.Login_add_load();
                }
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại.");
            }
            txtUsername.Texts = string.Empty;
            txtPassword.Texts = string.Empty;
            txtEmail.Texts = string.Empty;
        }
    }
}
