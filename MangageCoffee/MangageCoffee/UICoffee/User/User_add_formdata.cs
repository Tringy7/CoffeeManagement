using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee.User
{
    public partial class User_add_formdata : UserControl
    {
        public event EventHandler ButtonClickedFromData;

        public User_add_formdata()
        {
            InitializeComponent();
            user_add_datastaff1.ButtonClicked += User_add_datastaff1_ButtonClicked;

        }
        private void User_add_datastaff1_ButtonClicked(object sender, EventArgs e)
        {
            // Bong bóng sự kiện lên cấp trên
            ButtonClickedFromData?.Invoke(this, e);
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
