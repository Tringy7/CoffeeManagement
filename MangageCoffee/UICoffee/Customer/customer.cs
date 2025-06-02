using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
    public partial class Customer1 : Form
    {
        private UserBLL userBLL = new UserBLL();

        private BL_Product productBLL = new BL_Product();
        BL_Menu menu;
        public Customer1()
        {
            InitializeComponent();

            menu = new BL_Menu();
            menu_add1.txtName.Enabled = false;
            menu_add1.txtSDT.Enabled = false;
            menu_add1.CheckOut.Click += CheckOut_Click1;
            this.Load += Customer1_Load;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            menu_add1.BringToFront();
            Edit.BringToFront();
            Cart.BringToFront();
        }

        private void Customer1_Load(object sender, EventArgs e)
        {
            UserDTO user = userBLL.GetLoggedInUserInfo();
            menu_add1.txtName.Texts = user.FullName ?? "";
            menu_add1.txtSDT.Texts = user.Phone ?? "";
        }

        private void deleteOderHistory_Click(object sender, EventArgs e)
        {
            try
            {
                userBLL.ResetAllUserStatus();
            }
            catch (Exception ex)
            {
                Notice mess = new Notice("Error resetting user status!");
                mess.ShowDialog();
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

        DB_Main db = new DB_Main();

        private void CheckOut_Click1(object sender, EventArgs e)
        {
            UserDTO user = userBLL.GetLoggedInUserInfo();
            string error = "";
            decimal totalProfit = 0;
            DateTime orderDate = DateTime.Now.Date;
            int adminId = user.AdminID;
            List<OrderItemDTO> orderItems = new List<OrderItemDTO>();

            foreach (System.Windows.Forms.Control control in menu_add1.flowLayoutPaneloder_Menu.Controls)
            {
                Item_Order itemOrder = control as Item_Order;
                if (itemOrder != null)
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
                Notice mess = new Notice("No items to checkout!");
                mess.ShowDialog();
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
                        TimeSpan orderTime = DateTime.Now.TimeOfDay;
                        decimal totalAmount = (decimal)orderItem.UnitPrice * orderItem.Quantity;

                        bool inserted = db.InsertOrder(
                            orderItem.ItemID,
                            orderDate,
                            orderTime,
                            orderItem.Quantity,
                            (decimal)orderItem.UnitPrice,
                            totalAmount,
                            user.CustomerID,       
                            true,            
                            transaction,
                            ref error
                        );

                        if (!inserted)
                        {
                            transaction.Rollback();
                            Notice mess2 = new Notice("Failed to insert order!");
                            mess2.ShowDialog();
                            return;
                        }

                        Class_Menu menuItem = menu.getMenuItemByID(orderItem.ItemID);
                        if (menuItem != null && menuItem.ProductID != -1)
                        {
                            bool updated = productBLL.UpdateProductQuantity(menuItem.ProductID, orderItem.Quantity, ref error);
                            if (!updated)
                            {
                                transaction.Rollback();
                                Notice mess2 = new Notice("Failed to update quantity!");
                                mess2.ShowDialog();
                                return;
                            }

                            decimal itemProfit = (decimal)(orderItem.UnitPrice - menuItem.OriginalPrice) * orderItem.Quantity;
                            totalProfit += itemProfit;
                        }
                        else
                        {
                            transaction.Rollback();
                            Notice mess2 = new Notice("MenuItem not found!");
                            mess2.ShowDialog();
                            return;
                        }
                    }

                    bool profitSaved = db.SaveDailyProfit(orderDate, totalProfit, orderItems.Count, ref error, transaction);
                    if (!profitSaved)
                    {
                        transaction.Rollback();
                        Notice mess2 = new Notice("Failed to save daily profit!");
                        mess2.ShowDialog();
                        return;
                    }

                    transaction.Commit();
                    Notice mess = new Notice("Checkout successful!");
                    mess.ShowDialog();

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
                        Notice mess2 = new Notice("Error rolling back transaction!");
                        mess2.ShowDialog();
                    }

                    Notice mess = new Notice("Checkout failed!");
                    mess.ShowDialog();
                }
            }

            try
            {
                Bill bill = new Bill(orderItems, customerName, customerPhoneNumber);
                bill.ShowDialog();
            }
            catch (Exception ex)
            {
                Notice mess = new Notice("Error generating bill!");
                mess.ShowDialog();
            }
        }

        private void ClearOrderUI()
        {
            menu_add1.flowLayoutPaneloder_Menu.Controls.Clear();
            menu_add1.TotalMoney.Text = "0";
            menu_add1.textSearch.Text = "";
            loaddata();
        }

        public void loaddata()
        {

            List<Class_Menu> listMenuItem = menu.getMenuItemList();

            menu_add1.flowLayoutPanel_Menu.Controls.Clear();
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
                        Notice mess = new Notice("ItemData is null!");
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                userBLL.ResetAllUserStatus();
            }
            catch (Exception ex)
            {
                Notice mess = new Notice("Error resetting user status!");
                mess.ShowDialog();
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

        private void Edit_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            history_add1.BringToFront();
            Edit.SendToBack();
            Cart.SendToBack();
            back_menu.BringToFront();
        }

        private void back_menu_Click(object sender, EventArgs e)
        {
            menu_add1.BringToFront();
            Edit.BringToFront();
            Cart.BringToFront();
            back_menu.SendToBack();
        }
    }
}
