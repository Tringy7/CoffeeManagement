using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using MangageCoffee.BL;
using MangageCoffee.DTO;
using MangageCoffee.UICoffee.ManageDishes;

namespace MangageCoffee.UICoffee.Menu
{
    public partial class Menu_add : UserControl
    {
        BL_Menu menu;
        public Menu_add()
        {
            menu = new BL_Menu();   
            InitializeComponent();
            loaddata();
        }

        public void loaddata()
        {

            List<Class_Menu> listMenuItem = menu.getMenuItemList();

            flowLayoutPanel_Menu.Controls.Clear();
            //MessageBox.Show("Số lượng menu item: " + listMenuItem.Count);
            foreach (Class_Menu item_menu in listMenuItem)
            {

                Item item = new Item();
                item.setdata(item_menu); // Gán dữ liệu cho control
                item.SetParentMenu(this);

                // Đăng ký sự kiện chọn item
                item.ItemSelected += Item_ItemSelected;
                

                flowLayoutPanel_Menu.Controls.Add(item); // Thêm vào panel chính

            }
        }
        private void Item_ItemSelected(object sender, EventArgs e)
        {
            try
            {
                Item selectedItem = sender as Item;


                if (selectedItem != null)
                {
                    Class_Menu selectedMenuItem = selectedItem.menuData;
                    if (selectedMenuItem == null)
                    {
                        MessageBox.Show("ItemData is null!");
                        return;
                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Qr"] == null)
            {
                Qr qr = new Qr();
                qr.Show();
            }
        }

        private void flowLayoutPanel_Menu_Paint(object sender, PaintEventArgs e)
        {

        }
    // cập  nhật giá tiền
        public void UpdateTotalMoney()
        {
            double total = 0;

            foreach (Control control in flowLayoutPaneloder_Menu.Controls)
            {
                if (control is Item_Order item)
                {
                    total += item.UnitPrice * item.Quantity;
                }
            }

            TotalMoney.Text = total.ToString("C"); // Hiển thị dạng tiền tệ
        }

        private void TotalMoney_Click(object sender, EventArgs e)
        {
            UpdateTotalMoney();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textSearch.Text.Trim().ToLower();

            List<Class_Menu> listMenu = menu.getMenuItemList();

            if (!string.IsNullOrEmpty(keyword))
            {
                listMenu = listMenu
                    .Where(p => p.Name != null && p.Name.ToLower().Contains(keyword))
                    .ToList();
            }

            ShowProductList(listMenu);
        }

        private void ShowProductList(List<Class_Menu> listMenu)
        {
            flowLayoutPanel_Menu.Controls.Clear();

          
            foreach (Class_Menu Menu_item in listMenu)
            {
                Item item = new Item();
                item.setdata(Menu_item);

                // Gắn lại các sự kiện
                item.ItemSelected += Item_ItemSelected;


                // Thêm vào panel
                flowLayoutPanel_Menu.Controls.Add(item);
            }
        }
        private void ApplyFilterByMenuCategory(string category)
        {
            List<Class_Menu> listMenu = menu.getMenuItemList(); // lấy toàn bộ

            if (category == "All")
            {
                ShowMenuList(listMenu);
                return;
            }

            var filtered = listMenu
                .Where(item => item.Category == category)
                .ToList();

            ShowMenuList(filtered);
        }

        private void ShowMenuList(List<Class_Menu> menuList)
        {
            flowLayoutPanel_Menu.Controls.Clear();

            foreach (Class_Menu item_menu in menuList)
            {

                Item item = new Item();
                item.setdata(item_menu); // Gán dữ liệu cho control
                item.SetParentMenu(this);

                // Đăng ký sự kiện chọn item
                item.ItemSelected += Item_ItemSelected;


                flowLayoutPanel_Menu.Controls.Add(item); // Thêm vào panel chính

            }
        }
        private void FastFood_Click(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("FastFood");
        }

        private void Bakery_Click(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("Bakery");
        }

        private void ColdDrink_Click(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("Cold Drink");
        }

        private void HotDrink_Click(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("Hot Drink");
        }

        private void All_Click(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("All");
        }
    }
}
