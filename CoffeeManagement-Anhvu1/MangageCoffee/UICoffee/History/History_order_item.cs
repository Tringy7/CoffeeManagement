using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.ADO.NET.BLL;
using MangageCoffee.DTO;

namespace MangageCoffee.UICoffee.History
{
    public partial class History_order_item : UserControl
    {
        BL_history bl = null;
        public History_order_item()
        {
            bl = new BL_history();
            InitializeComponent();
            
        }

        public void setData(Class_Oder oderItem)
        {
            Class_Menu menuItem = bl.getMenuItemsByItemID(oderItem.ItemID);
            if (menuItem != null)
            {
                Name_oder_item.Text = menuItem.Name;
                Quantity.Text = oderItem.Quantity.ToString();
                unitPrice.Text = oderItem.Unitprice.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin món ăn với ItemID: " + oderItem.ItemID,
                                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
