using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MangageCoffee.UICoffee.Menu
{
    public partial class Item_Order : UserControl
    {
        private Menu_add parent;
        public string ItemName { get; set; }
        public int Quantity { get; set; } = 1;
        public double UnitPrice { get; set; }

        public Item_Order() // Cho Designer hoặc nơi không cần dữ liệu ngay
        {
            InitializeComponent();
        }

        public Item_Order(string name, double price, Menu_add parentMenu)
        {
           
            InitializeComponent();
            ItemName = name;
            UnitPrice = price;
            Quantity = 1;
            parent = parentMenu;
            UpdateUI();
        }

        public void IncreaseQuantity()
        {
            Quantity++;
            UpdateUI();
            (this.Parent as Menu_add)?.UpdateTotalMoney();
        }

        private void UpdateUI()
        {
            name_item.Text = ItemName;
            SoLuong.Text = Quantity.ToString();
            price.Text = (UnitPrice * Quantity).ToString("C");
        }


        private void Item_Order_Load_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Quantity > 1)
            {
                Quantity--;
                UpdateUI();
                this.parent?.UpdateTotalMoney(); // Giảm số lượng và cập nhật lại giao diện
            }
            else
            {
                // Nếu số lượng chỉ còn 1 thì xóa control khỏi parent
                var parent = this.Parent as FlowLayoutPanel;
                if (parent != null)
                {
                    parent.Controls.Remove(this);
                    this.Dispose();
                    this.parent?.UpdateTotalMoney();// Giải phóng tài nguyên
                }
            }
        }
    }
}
