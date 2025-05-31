using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee.Untils
{
    public partial class Mess : Form
    {
        public bool Proceed { get; private set; } = false;

        public Mess()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Proceed = false; // Người dùng chọn không làm gì
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Proceed = true; // Người dùng chọn chuyển tiếp
            this.Close();
        }
    }
}
