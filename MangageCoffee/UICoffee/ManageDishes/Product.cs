using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.ADO.NET.BLL;
using MangageCoffee.DTO;
using MangageCoffee.UICoffee.Customer;
using MangageCoffee.UICoffee.Menu;

namespace MangageCoffee.UICoffee.ManageDishes
{
    public partial class Product : UserControl
    {
        
        BL_Product bl_product;
        private Menu_add menu_Add;
        private Customer_Menu_add menu_Add1;
        public Product()
        {
            bl_product = new BL_Product();
            InitializeComponent();
            loadData();
            
        }
      
        private void Product_Load_1(object sender, EventArgs e)
        {
            checkBoxAll.CheckedChanged += CategoryCheckbox_CheckedChanged;
            checkBoxfastFood.CheckedChanged += CategoryCheckbox_CheckedChanged;
            checkBoxHotDrink.CheckedChanged += CategoryCheckbox_CheckedChanged;
            checkBoxColDrink.CheckedChanged += CategoryCheckbox_CheckedChanged;
            checkBoxBakery.CheckedChanged += CategoryCheckbox_CheckedChanged;
            textboxSearch.TextChanged += textboxSearch_TextChanged;
        }
        // truyền menu_add từ Cafe.cs vào product
        public void SetMenuControl(Menu_add menuControl)
        {
            this.menu_Add = menuControl;
            menu_Add.SetProductControl(this);
        }

        public void SetMenuControl1(Customer_Menu_add menuControl)
        {
            this.menu_Add1 = menuControl;
            menu_Add1.SetProductControl(this);
        }
        public void loadData()
        {
            Control buttonAdd = null;

            foreach (Control control in flowLayoutPanel_Product.Controls)
            {

                if (control.Name == "buttonaddProduct")
                {

                    buttonAdd = control;
                    break;
                }
            }

            // Xóa hết các control khỏi panel
            flowLayoutPanel_Product.Controls.Clear();

            // Thêm lại Buttonadd_product nếu tồn tại
            if (buttonAdd != null)
            {
                flowLayoutPanel_Product.Controls.Add(buttonAdd);
            }


            List<Class_product> listProduct = bl_product.getProductList();


            foreach (Class_product product in listProduct)
            {

                Manage_item item = new Manage_item();
                item.setdata(product); // Gán dữ liệu cho control

                item.SetMenuParent(menu_Add);

                // Đăng ký sự kiện chọn item
                item.ItemSelected += Item_ItemSelected;
                // đăng ký sự kiện mờ edit
                item.EditButtonClicked += Item_EditButtonClicked;
                // đăng ký sự kiện xoá
                item.SetProductControl(this); // truyền chính Product vào cho item
                item.DeleteButtonClicked += Item_DeleteButtonClicked;
                // đăng ký sự kiện chỉnh status
                item.HideButtonClicked += Item_HideButtonClicked;
                item.ShowButtonClicked += Item_ShowButtonClicked;


                flowLayoutPanel_Product.Controls.Add(item); // Thêm vào panel chính

            }

            total_Product.Text = listProduct.Count.ToString();

        }
        private void Item_HideButtonClicked(object sender, EventArgs e)
        {
            // Có thể xử lý thêm nếu cần
            loadData();
        }

        private void Item_ShowButtonClicked(object sender, EventArgs e)
        {
            // Có thể xử lý thêm nếu cần
            loadData();
        }

        private void Item_ItemSelected(object sender, EventArgs e)
        {
            try
            {
                Manage_item selectedItem = sender as Manage_item;


                if (selectedItem != null)
                {
                    Class_product selectedProduct = selectedItem.ProductData;
                    if (selectedProduct == null)
                    {
                        MessageBox.Show("ProductData is null!");
                        return;
                    }

                    //MessageBox.Show("Bạn đã chọn: " + selectedProduct.Name_Product);

                    Manage_itemlist manage_Itemlist = new Manage_itemlist();
                    manage_Itemlist.Setdata(selectedProduct);

                    manage_itemlist_Product.Controls.Clear();
                    manage_itemlist_Product.Controls.Add(manage_Itemlist);
                    manage_itemlist_Product.Visible = true;
                    manage_itemlist_Product.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Item_EditButtonClicked(object sender, EventArgs e)
        {

        }

        private void Item_DeleteButtonClicked(object sender, EventArgs e)
        {

        }

























        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }
        private void CategoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void ApplyFilterByCategory()
        {

            List<Class_product> listProduct = bl_product.getProductList();

            if (checkBoxAll.Checked)
            {
                ShowProductList(listProduct);
                return;
            }

            List<string> selectedCategories = new List<string>();
            if (checkBoxfastFood.Checked) selectedCategories.Add("FastFood");
            if (checkBoxHotDrink.Checked) selectedCategories.Add("Hot Drink");
            if (checkBoxColDrink.Checked) selectedCategories.Add("Cold Drink");
            if (checkBoxBakery.Checked) selectedCategories.Add("Bakery");

            var filtered = listProduct
                .Where(p => selectedCategories.Contains(p.Category))
                .ToList();

            ShowProductList(filtered);
        }
        private void ShowProductList(List<Class_product> list)
        {
            Control buttonAdd = null;

            foreach (Control control in flowLayoutPanel_Product.Controls)
            {

                if (control.Name == "buttonaddProduct")
                {

                    buttonAdd = control;
                    break;
                }
            }

            // Xóa hết các control khỏi panel
            flowLayoutPanel_Product.Controls.Clear();

            // Thêm lại Buttonadd_product nếu tồn tại
            if (buttonAdd != null)
            {
                flowLayoutPanel_Product.Controls.Add(buttonAdd);
            }

            foreach (Class_product product in list)
            {
                Manage_item item = new Manage_item();
                item.setdata(product);

                // Gắn lại các sự kiện
                item.ItemSelected += Item_ItemSelected;
                item.EditButtonClicked += Item_EditButtonClicked;
                //item.DeleteButtonClicked += Item_DeleteButtonClicked;

                // Thêm vào panel
                flowLayoutPanel_Product.Controls.Add(item);
            }
            total_Product.Text = list.Count.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ManageDishes_edit edit = new ManageDishes_edit();
            edit.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ManageDishes_edit edit = new ManageDishes_edit();
            edit.Show();
        }

        private void flowLayoutPanel_Product_Paint(object sender, PaintEventArgs e)
        {

        }

        private void insert_product_Click(object sender, EventArgs e)
        {
            ManageDishes_edit addForm = new ManageDishes_edit();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Sau khi thêm thành công, cập nhật danh sách
                loadData();
                menu_Add.loaddata();
                //menu_Add1.loaddata();
            }
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            ManageDishes_edit addForm = new ManageDishes_edit();

            if (addForm.ShowDialog() == DialogResult.OK)
            {

                // Sau khi thêm thành công, cập nhật danh sách
                loadData();
                menu_Add.loaddata();
                //menu_Add1.loaddata();
            }
        }

        private void textboxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textboxSearch.Text.Trim().ToLower();

            List<Class_product> listProduct = bl_product.getProductList();

            if (!string.IsNullOrEmpty(keyword))
            {
                listProduct = listProduct
                    .Where(p => p.Name_Product != null && p.Name_Product.ToLower().Contains(keyword))
                    .ToList();
            }

            ShowProductList(listProduct);
        }

        private void flowLayoutPanel_Product_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2ButtonFillter_Click(object sender, EventArgs e)
        {
            Filte_Product.Visible = !Filte_Product.Visible;
        }

        private void total_Product_Click(object sender, EventArgs e)
        {

        }

        private void Filte_Product_Paint(object sender, PaintEventArgs e)
        {

        }

  
    }
}
