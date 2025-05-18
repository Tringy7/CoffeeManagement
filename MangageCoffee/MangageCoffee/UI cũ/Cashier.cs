using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee
{

    public partial class Cashier : Form
    {

        private int targetTop;

        public Cashier()
        {
            InitializeComponent();
            targetTop = btn1.Top;
            moveTimer.Start();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            targetTop = btn3.Top;
            moveTimer.Start();
            menu1.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 5;
            if (panel.Top < targetTop)
            {
                panel.Top += speed;
                if (panel.Top > targetTop) panel.Top = targetTop;
            }
            else if (panel.Top > targetTop)
            {
                panel.Top -= speed;
                if (panel.Top < targetTop) panel.Top = targetTop;
            }

            if (panel.Top == targetTop)
            {
                moveTimer.Stop();
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            targetTop = btn1.Top;
            moveTimer.Start();
            dashboard_Cashier1.BringToFront();
        }
    }
}
