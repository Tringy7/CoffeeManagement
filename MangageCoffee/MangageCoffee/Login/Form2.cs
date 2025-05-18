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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // <-- Đặt giữa màn hình

            login_add1.begin = this;
            signup_add1.begin = this;
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
