using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangageCoffee.UICoffee.Untils
{
    public partial class Bill_item : UserControl
    {
        public Bill_item()
        {
            InitializeComponent();
        }

        public void SetItemData(string itemName, int quantity, double unitPrice)
        {
            lblName.Text = itemName;
            lblQuantity.Text = quantity.ToString();
            lblUnitprice.Text = unitPrice.ToString("C");
            lblTotal.Text = (quantity * unitPrice).ToString("C");
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
