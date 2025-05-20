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
    public partial class User_add_editprofile : UserControl
    {
        public event EventHandler ButtonClickedFromData;
        public User_add_editprofile()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ButtonClickedFromData?.Invoke(this, e);
        }
    }
}
