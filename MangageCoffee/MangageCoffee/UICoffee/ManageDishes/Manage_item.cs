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
using MangageCoffee.UICoffee.Menu;
using System.IO;
using MangageCoffee.ADO.NET.BLL;
using MangageCoffee.UICoffee.Customer;
using MangageCoffee.UICoffee.Untils;

namespace MangageCoffee.UICoffee.ManageDishes
{
    public partial class Manage_item : UserControl
    {
        public event EventHandler ItemSelected;
        public event EventHandler DeleteButtonClicked;
        public event EventHandler HideButtonClicked;
        public event EventHandler ShowButtonClicked;

        private Menu_add menuParent;
        //private Customer_Menu_add menuParent1;
        BL_Product bl = null;
        public Image ProductImage
        {
            get { return ptbImage.Image; }
            set { ptbImage.Image = value; }
        }

        public Manage_item()
        {
            InitializeComponent();

            bl = new BL_Product();
            
            this.Click += Manage_item_Click; 
            foreach (Control c in this.Controls) 
                c.Click += Manage_item_Click;
        }

        
        public void SetMenuParent(Menu_add parent)
        {
            this.menuParent = parent;
        }

        //public void SetMenuParent1(Customer_Menu_add parent)
        //{
        //    this.menuParent1 = parent;
        //}
        public Class_product ProductData { get; private set; }
        private void Manage_item_Click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }

        public void setdata(Class_product product)
        {
            this.ProductData = product;
            Name_product.Text = product.Name_Product;
            status_product.Text = product.Status;
            if (!string.IsNullOrEmpty(product.ImagePath))
            {
                try
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    string imageFullPath = Path.Combine(imagesFolder, product.ImagePath);

                    if (File.Exists(imageFullPath)) // Check if file exists
                    {
                        ProductImage = Image.FromFile(imageFullPath);
                    }
                    else
                    {
                        Notice mess = new Notice("Image file not found!");
                        mess.ShowDialog();
                        ProductImage = Properties.Resources._default;
                    }
                }
                catch (Exception ex)
                {
                    Notice mess = new Notice("Error loading image!");
                    mess.ShowDialog();
                    ProductImage = Properties.Resources._default;
                }
            }
            else
            {
                ProductImage = Properties.Resources._default;
            }
        }
        public event EventHandler EditButtonClicked;

        private void Edit_product_Click(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, EventArgs.Empty);
            this.menuParent?.loaddata();
        }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////
    /// </summary>
        private Product productControl;

        public void SetProductControl(Product product)
        {
            this.productControl = product;
        }

        public event EventHandler RequestReloadMenu;

        private void delete_Click(object sender, EventArgs e)
        {
            string error = " ";
            bl.SetProductStatus1(ProductData.Id, ref error);  // ví dụ là ẩn sản phẩm

            HideButtonClicked?.Invoke(this, EventArgs.Empty); // Gọi sự kiện
            menuParent?.loaddata(); // Load lại dữ liệu

        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            string error = " ";
            bl.SetProductStatus2(ProductData.Id, ref error); // ví dụ là hiện lại sản phẩm

            ShowButtonClicked?.Invoke(this, EventArgs.Empty); // Gọi sự kiện
            menuParent?.loaddata(); // Load lại dữ liệu

        }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delete_product_Click(object sender, EventArgs e)
        {

            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
            this.menuParent?.loaddata();

        }

       
    }
}
