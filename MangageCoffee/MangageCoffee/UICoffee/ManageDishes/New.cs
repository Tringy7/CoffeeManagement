using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee.ManageDishes
{
    public partial class New : UserControl
    {
        public New()
        {
            InitializeComponent();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ManageDishes_edit edit = new ManageDishes_edit();
            edit.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ManageDishes_edit edit = new ManageDishes_edit();
            edit.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ManageDishes_edit edit = new ManageDishes_edit();
            edit.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Filter.Visible = !Filter.Visible;
        }
    }
}
