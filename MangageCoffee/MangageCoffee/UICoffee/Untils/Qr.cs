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
    public partial class Qr : Form
    {
        public Qr()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // <-- Đặt giữa màn hình

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
