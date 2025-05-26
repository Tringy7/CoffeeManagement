using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.DTO;

namespace MangageCoffee.UICoffee.ManageDishes
{
    public partial class Manage_itemlist : UserControl
    {
        public Manage_itemlist()
        {
            InitializeComponent();
        }
        public void Setdata(Class_product product)
        {
            GiaGoc.Text = product.OriginalPrice.ToString();
            TenSP.Text = product.Name_Product;
            GiaSP.Text = product.Price.ToString();
            SoLuong_SP.Text = product.Quantity.ToString();
            loaiSP.Text = product.Category;
            TinhTrang_sp.Text = product.Status.ToString();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ManageDishes_edit manage = new ManageDishes_edit();
            manage.Show();
        }

        private void Panel_Product_info_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
