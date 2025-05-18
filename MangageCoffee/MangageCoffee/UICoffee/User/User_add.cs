using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee
{
    public partial class User_add : UserControl
    {
        public User_add()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            user_add_editprofile1.BringToFront();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            user_add_formdata1.BringToFront();  
        }
    }
}
