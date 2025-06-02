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
using MangageCoffee.UICoffee.ManageDishes;
using System.IO;
using System.Globalization;
using MangageCoffee.UICoffee.Customer;
using MangageCoffee.UICoffee.Untils;

namespace MangageCoffee.UICoffee.Menu
{
    public partial class Item : UserControl
    {
        private Menu_add parentMenu;
        public event EventHandler ItemSelected;
        public Item()
        {
            InitializeComponent();
            this.Click += Menu_item_click;
            foreach (Control c in this.Controls) 
                c.Click += Menu_item_click;
        }


        // load dữ liệu
        public Class_Menu menuData { get; private set; }
        private void Menu_item_click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }
        public Image ItemImage
        {
            get { return ptbImage.Image; }
            set { ptbImage.Image = value; }
        }
        public void setdata(Class_Menu menuItem)
        {
            this.menuData = menuItem;
            name_Item.Text = menuItem.Name;
            Item_cost.Text = menuItem.Price.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
            if (!string.IsNullOrEmpty(menuItem.ImagePath))
            {
                try
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    string imageFullPath = Path.Combine(imagesFolder, menuItem.ImagePath);

                    if (File.Exists(imageFullPath)) 
                    {
                        ItemImage = Image.FromFile(imageFullPath);
                    }
                    else
                    {
                        Notice mess = new Notice("Image file not found!");
                        mess.ShowDialog();
                        ItemImage = Properties.Resources._default;
                    }
                }
                catch (Exception ex)
                {
                    Notice mess = new Notice("Error loading image!");
                    mess.ShowDialog();
                    ItemImage = Properties.Resources._default;
                }
            }
            else
            {
                ItemImage = Properties.Resources._default;
            }
        }
        public void SetParentMenu(Menu_add menu)
        {
            this.parentMenu = menu;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            if (parentMenu == null || menuData == null)
                return;

            var panel = parentMenu.flowLayoutPaneloder_Menu;
            int quantityToAdd = (int)numeric.Value;

            try
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is Item_Order order && order.ItemID == menuData.Item_id) 
                    {
                        order.IncreaseQuantity(quantityToAdd);
                        UpdateTotal(); // Chỉ gọi UpdateTotal một lần
                        return;
                    }
                    //else if (control is Item_Order order && order.ItemName == menuData.Name)
                    //{
                    //    order.IncreaseQuantity(quantityToAdd);
                    //    UpdateTotal();
                    //    return;
                    //}
                }

                // Tạo Item_Order mới
                Item_Order newOrder = new Item_Order(menuData.Name, menuData.Price, parentMenu, quantityToAdd);
                newOrder.ItemID = menuData.Item_id; 
                newOrder.ImagePath = menuData.ImagePath;
                newOrder.UpdateUI();

                panel.Controls.Add(newOrder);
                UpdateTotal(); 
            }
            catch (Exception ex)
            {
                Notice mess = new Notice("Error adding item!");
                mess.ShowDialog();
            }
        }

        private void UpdateTotal()
        {
            parentMenu.UpdateTotalMoney();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Item_Load(object sender, EventArgs e)
        {

        }
    }
}
