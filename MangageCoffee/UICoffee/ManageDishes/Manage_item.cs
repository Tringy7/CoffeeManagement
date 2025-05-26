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

namespace MangageCoffee.UICoffee.ManageDishes
{
    public partial class Manage_item : UserControl
    {
        public event EventHandler ItemSelected;
        public event EventHandler DeleteButtonClicked;
        private Menu_add menuParent;


        public Manage_item()
        {
            InitializeComponent();

            this.Click += Manage_item_Click; // click vào control
            foreach (Control c in this.Controls) // click vào con cũng tính
                c.Click += Manage_item_Click;
        }
        public void SetMenuParent(Menu_add parent)
        {
            this.menuParent = parent;
        }
        public Class_product ProductData { get; private set; }
        private void Manage_item_Click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }
        public void setdata(Class_product product)
        {
            this.ProductData = product;
            Name_product.Text = product.Name_Product;
            price_product.Text = product.Price.ToString("C");
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public event EventHandler EditButtonClicked;

        private void Edit_product_Click(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, EventArgs.Empty); // Kích hoạt sự kiện 
            this.menuParent?.loaddata();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
            this.menuParent?.loaddata();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
