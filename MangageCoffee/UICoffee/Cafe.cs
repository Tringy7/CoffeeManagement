using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

namespace MangageCoffee
{
    public partial class Cafe : Form
    {
        BL_Menu menu;
        private BL_Order orderBLL = new BL_Order();
        private BL_Product productBLL = new BL_Product();
        private Product productControl;
        DB_Main db = new DB_Main();
        public Cafe()
        {
            InitializeComponent();

            menu = new BL_Menu();
            productControl = new Product();
            new1.SetMenuControl(menu_add1);
            this.StartPosition = FormStartPosition.CenterScreen; // <-- Đặt giữa màn hình

        }

        private UserBLL userBLL = new UserBLL();

        private void btnHome_Click(object sender, EventArgs e)
        {
            home1.BringToFront();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            user_add1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            menu_add1.BringToFront();  
            menu_add1.CheckOut.Click += Click;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                userBLL.ResetAllUserStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi reset trạng thái người dùng: " + ex.Message);
                return;
            }

            if (Application.OpenForms["Form2"] == null)
            {
                Form2 login = new Form2();
                login.Show();
                this.Hide(); 
            }
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            history_add1.BringToFront();
        }

        private void Click(object sender, EventArgs e)
        {
            UserDTO user = userBLL.GetLoggedInUserInfo();
            string error = "";
            decimal totalProfit = 0;
            DateTime orderDate = DateTime.Now.Date;
            int adminId = user.AdminID;
            List<OrderItemDTO> orderItems = new List<OrderItemDTO>();

            foreach (Control control in menu_add1.flowLayoutPaneloder_Menu.Controls)
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
            string customerName = menu_add1.txtName.Texts;
            string customerPhoneNumber = menu_add1.txtSDT.Texts;

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
            menu_add1.flowLayoutPaneloder_Menu.Controls.Clear();
            menu_add1.txtName.Texts = "";
            menu_add1.txtSDT.Texts = "";
            menu_add1.TotalMoney.Text = "0";
            menu_add1.textSearch.Text = "";
            loaddata();
        }

        public void loaddata()
        {

            List<Class_Menu> listMenuItem = menu.getMenuItemList();

            menu_add1.flowLayoutPanel_Menu.Controls.Clear();
            //MessageBox.Show("Số lượng menu item: " + listMenuItem.Count);
            foreach (Class_Menu item_menu in listMenuItem)
            {

                Item item = new Item();
                item.setdata(item_menu);
                item.SetParentMenu(menu_add1);



                item.ItemSelected += Item_ItemSelected;

                Manage_item manage_Item = new Manage_item();
                manage_Item.SetMenuParent(menu_add1);


                menu_add1.flowLayoutPanel_Menu.Controls.Add(item);

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


        private void home1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form2 = new Form2();
            form2.Close();

        }
    }
}
