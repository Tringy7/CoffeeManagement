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

            LoadData();
        }

        public void LoadData()
        {
            for (int i = 0; i < 10; i++)
            {
                Manage_item item = new Manage_item();  // Tạo mới mỗi lần
                flowLayoutPanel1.Controls.Add(item);
            }
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

        private void manage_item1_Load(object sender, EventArgs e)
        {

        }
    }
}
