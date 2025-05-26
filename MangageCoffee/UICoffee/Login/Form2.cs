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

namespace MangageCoffee
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.AcceptButton = login_add1.btnLogin;
            this.StartPosition = FormStartPosition.CenterScreen;

            login_add1.begin = this;
            signup_add1.begin = this;
            login_add1.exit += Login_add1_exit;
            signup_add1.exit += Signup_add1_exit;
        }

        private void Signup_add1_exit(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Login_add1_exit(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public void Login_add_load()
        {
            login_add1.BringToFront();
        }

        public void Signup_add_load()
        {
            signup_add1.BringToFront();
            
        }

    }
}
