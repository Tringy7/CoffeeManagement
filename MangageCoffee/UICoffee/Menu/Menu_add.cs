using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.ADO.NET.BLL;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;
using MangageCoffee.UICoffee.ManageDishes;
using MangageCoffee.UICoffee.Untils;

namespace MangageCoffee.UICoffee.Menu
{
    public partial class Menu_add : UserControl
    {
        BL_Menu menu;
        private BL_Order orderBLL = new BL_Order();
        private BL_Product productBLL = new BL_Product();
        private Product productControl;
        public event EventHandler ButtonClicked;
        public Menu_add()
        {
            menu = new BL_Menu();
            InitializeComponent();
            loaddata();
            productControl = new Product();
        }
        public void SetProductControl(Product product)
        {
            this.productControl = product;
        }


        public void loaddata()
        {

            List<Class_Menu> listMenuItem = menu.getMenuItemList();

            flowLayoutPanel_Menu.Controls.Clear();
            foreach (Class_Menu item_menu in listMenuItem)
            {

                Item item = new Item();
                item.setdata(item_menu); // Gán dữ liệu cho control 
                item.SetParentMenu(this);
                
                
                // Đăng ký sự kiện chọn item
                
                item.ItemSelected += Item_ItemSelected;

                Manage_item manage_Item = new Manage_item();
                manage_Item.SetMenuParent(this);
                


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
                        Notice mess = new Notice("ItemData is null!!");
                        mess.ShowDialog();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Notice mess = new Notice("Error!");
                mess.ShowDialog();
            }
        }
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
         
            TotalMoney.Text = total.ToString("C0", CultureInfo.GetCultureInfo("vi-VN")); // Hiển thị dạng tiền tệ
        }

        private void TotalMoney_Click(object sender, EventArgs e)
        {
            UpdateTotalMoney();
        }




        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Qr"] == null)
            {
                Qr qr = new Qr();
                qr.Show();
            }
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

                item.ItemSelected += Item_ItemSelected;

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

       
        private void Menu_add_Load(object sender, EventArgs e)
        {

        }

        private void FastFood_Click_1(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("FastFood");
        }

        private void HotDrink_Click_1(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("Hot Drink");
        }

        private void ColdDrink_Click_1(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("Cold Drink");
        }

        private void All_Click_1(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("All");
        }

        private void Bakery_Click_1(object sender, EventArgs e)
        {
            ApplyFilterByMenuCategory("Bakery");
        }

        private void PayNotChoose_Click(object sender, EventArgs e)
        {
            CheckOut.Enabled = true;
        }

        private void QRNotChoose_Click(object sender, EventArgs e)
        {
            Qr qr = new Qr();
            qr.Show();
            CheckOut.Enabled = true;

        }
        private UserBLL userBLL = new UserBLL();
        DB_Main db = new DB_Main();
        private void CheckOut_Click(object sender, EventArgs e)
        {

           ButtonClicked?.Invoke(this, EventArgs.Empty);
            productControl.loadData();

        }

        private void flowLayoutPaneloder_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TotalMoney_Click_1(object sender, EventArgs e)
        {

        }
    }
}

