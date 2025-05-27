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

namespace MangageCoffee.UICoffee.Menu
{
    public partial class Item : UserControl
    {
        private Menu_add parentMenu;
        public event EventHandler ItemSelected;
        public Item()
        {
            InitializeComponent();
            this.Click += Menu_item_click; // click vào control
            foreach (Control c in this.Controls) // click vào con cũng tính
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
            Item_cost.Text = menuItem.Price.ToString("C");
            if (!string.IsNullOrEmpty(menuItem.ImagePath))
            {
                try
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    string imageFullPath = Path.Combine(imagesFolder, menuItem.ImagePath);

                    if (File.Exists(imageFullPath)) // Check if file exists
                    {
                        ItemImage = Image.FromFile(imageFullPath);
                    }
                    else
                    {
                        Console.WriteLine("Image file not found: " + imageFullPath);
                        ItemImage = Properties.Resources._default;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading image: " + ex.Message);
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

            // Tìm xem đã có món này trong panel chưa
            foreach (Control control in panel.Controls)
            {
                if (control is Item_Order order && order.ItemName == menuData.Name)
                {
                    order.IncreaseQuantity(); // Tăng số lượng nếu đã tồn tại
                    parentMenu.UpdateTotalMoney();
                    return;
                }
            }

            Item_Order newOrder = new Item_Order(menuData.Name, menuData.Price, parentMenu);
            newOrder.ImagePath = menuData.ImagePath; // Gán đường dẫn ảnh từ menuData
            newOrder.UpdateUI(); // Cập nhật lại UI để hiển thị ảnh và thông tin

            panel.Controls.Add(newOrder);
            parentMenu.UpdateTotalMoney(); // Cập nhật tổng tiền
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
