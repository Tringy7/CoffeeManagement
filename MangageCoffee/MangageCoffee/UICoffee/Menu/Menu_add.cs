using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee.Menu
{
    public partial class Menu_add : UserControl
    {
        public Menu_add()
        {
            InitializeComponent();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Qr"] == null)
            {
                Qr qr = new Qr();
                qr.Show();
            }
        }
    }
}
