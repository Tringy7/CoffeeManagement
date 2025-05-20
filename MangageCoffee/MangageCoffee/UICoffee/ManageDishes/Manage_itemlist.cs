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
    public partial class Manage_itemlist : UserControl
    {
        public Manage_itemlist()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ManageDishes_edit manage = new ManageDishes_edit();
            manage.Show();
        }
    }
}
