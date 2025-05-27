using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MangageCoffee.UICoffee.Menu
{

    public partial class Item_Order : UserControl
    {
        private Menu_add parent;
        public string ItemName { get; set; }
        public int Quantity { get; set; } = 1;
        public double UnitPrice { get; set; }
        public string ImagePath { get; set; } // Add ImagePath property
        public Image ItemImage  // Add ItemImage property
        {
            get { return ptbImage.Image; }
            set { ptbImage.Image = value; }
        }
        public Item_Order()
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

        public void UpdateUI()
        {
            name_item.Text = ItemName;
            SoLuong.Text = Quantity.ToString();
            price.Text = (UnitPrice * Quantity).ToString("C");
            if (!string.IsNullOrEmpty(ImagePath))
            {
                try
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    string imageFullPath = Path.Combine(imagesFolder, ImagePath);

                    if (File.Exists(imageFullPath))
                    {
                        ItemImage = Image.FromFile(imageFullPath);
                    }
                    else
                    {
                        Console.WriteLine("Image file not found: " + imageFullPath);
                        ptbImage.Image = Properties.Resources._default; // Or a default image
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading image: " + ex.Message);
                    ptbImage.Image = Properties.Resources._default; // Or a default image
                }
            }
            else
            {
                ptbImage.Image = Properties.Resources._default; // Or a default image if no path
            }
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
        private void Item_Order_Load(object sender, EventArgs e)
        {

        }

        private void name_item_Click(object sender, EventArgs e)
        {

        }
    }
}
