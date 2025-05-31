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
using System.Xml.Linq;
using MangageCoffee.ADO.NET.BLL;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;
using MangageCoffee.UICoffee.ManageDishes;
using MangageCoffee.UICoffee.Menu;
using MangageCoffee.UICoffee.Untils;

namespace MangageCoffee.UICoffee.Customer
{
    public partial class Customer_Menu_add : UserControl
    {
        BL_Menu menu;
        private BL_Order orderBLL = new BL_Order();
        private BL_Product productBLL = new BL_Product();
        private Product productControl;
        public event EventHandler ButtonClicked;
        public Customer_Menu_add()
        {
            menu = new BL_Menu();
            InitializeComponent();
            loaddata();
            productControl = new Product();
            CheckOut.Click += Click;
        }
        public void SetProductControl(Product product)
        {
            this.productControl = product;
        }

        public void loaddata()
        {

            List<Class_Menu> listMenuItem = menu.getMenuItemList();

            flowLayoutPanel_Menu.Controls.Clear();
            //MessageBox.Show("Số lượng menu item: " + listMenuItem.Count);
            foreach (Class_Menu item_menu in listMenuItem)
            {

                Item item = new Item();
                item.setdata(item_menu);
                item.SetParentMenu1(this);



                item.ItemSelected += Item_ItemSelected;

                Manage_item manage_Item = new Manage_item();
                manage_Item.SetMenuParent1(this);


                flowLayoutPanel_Menu.Controls.Add(item); 

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

            TotalMoney.Text = total.ToString("C", CultureInfo.GetCultureInfo("vi-VN")); // Hiển thị dạng tiền tệ
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
                item.SetParentMenu1(this);

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

        }

        private void Click(object sender, EventArgs e)
        {
            UserDTO user = userBLL.GetLoggedInUserInfo();
            string error = "";
            decimal totalProfit = 0;
            DateTime orderDate = DateTime.Now.Date;
            int adminId = user.AdminID;
            List<OrderItemDTO> orderItems = new List<OrderItemDTO>();

            foreach (Control control in flowLayoutPaneloder_Menu.Controls)
            {
                if (control is Item_Order itemOrder)
                {
                    orderItems.Add(new OrderItemDTO
                    {
                        ItemID = itemOrder.ItemID,
                        Name = itemOrder.ItemName,
                        Quantity = itemOrder.Quantity,
                        UnitPrice = itemOrder.UnitPrice
                    });
                }
            }

            if (orderItems.Count == 0)
            {
                MessageBox.Show("No items to checkout!");
                return;
            }
            string customerName = user.FullName;
            string customerPhoneNumber = user.Phone;

            using (SqlTransaction transaction = db.BeginTransaction())
            {
                try
                {
                    foreach (OrderItemDTO orderItem in orderItems)
                    {
                        Class_Menu menuItem = menu.getMenuItemByID(orderItem.ItemID);
                        if (menuItem != null && menuItem.ProductID != -1)
                        {
                            bool updated = productBLL.UpdateProductQuantity(menuItem.ProductID, orderItem.Quantity, ref error);
                            if (!updated)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Failed to update quantity for ItemID {orderItem.ItemID}.\nError: {error}");
                                return;
                            }
                            else
                            {
                                productControl.loadData();
                            }

                            decimal itemProfit = (decimal)(orderItem.UnitPrice - menuItem.OriginalPrice) * orderItem.Quantity;
                            totalProfit += itemProfit;
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show($"MenuItem not found for ItemID {orderItem.ItemID}.");
                            return;
                        }
                    }

                    bool profitSaved = db.SaveDailyProfit(orderDate, totalProfit, orderItems.Count, ref error, transaction);
                    if (!profitSaved)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Failed to save daily profit.\nError: " + error);
                        return;
                    }

                    transaction.Commit();
                    MessageBox.Show($"Checkout successful!\nTotal Profit: {totalProfit.ToString("C")}");

                    ClearOrderUI();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show($"Error rolling back transaction: {rollbackEx.Message}");
                    }

                    MessageBox.Show("Checkout failed: " + ex.Message);
                }
            }


            try
            {
                Bill bill = new Bill(orderItems, customerName, customerPhoneNumber);
                bill.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating bill: " + ex.Message);
            }
        }


        private void ClearOrderUI()
        {
            flowLayoutPaneloder_Menu.Controls.Clear();
            TotalMoney.Text = "0";
            textSearch.Text = "";
            loaddata();
        }

        private void flowLayoutPaneloder_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TotalMoney_Click_1(object sender, EventArgs e)
        {

        }
    }
}
