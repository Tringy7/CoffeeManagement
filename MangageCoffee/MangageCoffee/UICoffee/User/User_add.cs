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
            user_add_formdata1.ButtonClickedFromData += User_add_datastaff1_ButtonClicked;
            user_add_editprofile1.ButtonClickedFromData += User_add_edit_ButtonClicked;
        }
        private void User_add_edit_ButtonClicked(object sender, EventArgs e)
        {
            user_add_formdata1.BringToFront();
        }


        private void User_add_datastaff1_ButtonClicked(object sender, EventArgs e)
        {
            user_add_editprofile1.BringToFront();
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
