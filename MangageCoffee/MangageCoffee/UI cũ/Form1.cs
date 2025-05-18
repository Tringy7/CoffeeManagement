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
    public partial class Form1 : Form
    {

        private int targetTop;

        public Form1()
        {
            InitializeComponent();
            targetTop = btn1.Top;
            moveTimer.Start();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            targetTop = btn2.Top;
            moveTimer.Start();
            user1.BringToFront();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            targetTop = btn1.Top;
            moveTimer.Start();
            dashboard1.BringToFront();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            targetTop = btn3.Top;
            moveTimer.Start();
            menu1.BringToFront();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            targetTop = btn4.Top;
            moveTimer.Start();
            products1.BringToFront();
        }


        private void moveTimer_Tick(object sender, EventArgs e)
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            targetTop = btn5.Top;
            moveTimer.Start();
            history1.BringToFront();
        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }
    }
}
