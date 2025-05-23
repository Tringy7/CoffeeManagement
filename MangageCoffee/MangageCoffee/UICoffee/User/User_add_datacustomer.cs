using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.DTO;

namespace MangageCoffee.UICoffee.User
{
    public partial class User_add_datacustomer : UserControl
    {
        public event EventHandler DetailButtonClicked;
        public User_add_datacustomer()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DetailButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public UserDTO UserData
        {
            set
            {
                if (value != null)
                {
                    lblID.Text = value.UserID.ToString();
                    lblHo.Text = value.FullName; 
                    lblGioiTinh.Text = value.Gender;
                    lblNgaySinh.Text = value.DateOfBirth?.ToString("dd/MM/yyyy");
                    lblSDT.Text = value.Phone;
                }
            }
        }
    }
}
