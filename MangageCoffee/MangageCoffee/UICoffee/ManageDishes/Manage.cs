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
    public partial class Manage : UserControl
    {
        public Manage()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms["ManageDishes_edit"] == null)
            {
                ManageDishes_edit ManageDishes_edit = new ManageDishes_edit();
                ManageDishes_edit.Show();
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ManageDishes_edit"] == null)
            {
                ManageDishes_edit ManageDishes_edit = new ManageDishes_edit();
                ManageDishes_edit.Show();
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Filter.Visible = !Filter.Visible;
        }

        private void manage_itemlist2_Load(object sender, EventArgs e)
        {

        }
    }
}
