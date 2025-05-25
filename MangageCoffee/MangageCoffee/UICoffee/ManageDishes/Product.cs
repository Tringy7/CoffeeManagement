using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.BL;
using MangageCoffee.DTO;
using MangageCoffee.UICoffee.Menu;

namespace MangageCoffee.UICoffee.ManageDishes
{
   
    public partial class Product : UserControl
    {
        BL_Product bl_product;
        private Menu_add menu_Add;
        public Product()
        {
            bl_product = new BL_Product();
            InitializeComponent();
            loadData();
        }
    // truyền menu_add từ Cafe.cs vào product
        public void SetMenuControl(Menu_add menuControl)
        {
            this.menu_Add = menuControl;
            //MessageBox.Show("gọi menu_add");
        }
        private void Product_Load(object sender, EventArgs e)
        {
            checkBoxAll.CheckedChanged += CategoryCheckbox_CheckedChanged;
            checkBoxfastFood.CheckedChanged += CategoryCheckbox_CheckedChanged;
            checkBoxHotDrink.CheckedChanged += CategoryCheckbox_CheckedChanged;
            checkBoxColDrink.CheckedChanged += CategoryCheckbox_CheckedChanged;
            checkBoxBakery.CheckedChanged += CategoryCheckbox_CheckedChanged;
            textboxSearch.TextChanged += textboxSearch_TextChanged;


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
                item.DeleteButtonClicked += Item_DeleteButtonClicked;

                flowLayoutPanel_Product.Controls.Add(item); // Thêm vào panel chính

            }

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
            Manage_item selectedItem = sender as Manage_item;
            if (selectedItem != null)
            {
                Class_product selectedProduct = selectedItem.ProductData;
                if (selectedProduct == null)
                {
                    MessageBox.Show("ProductData is null!");
                    return;
                }

                ManageProduct_edit editForm = new ManageProduct_edit();
                editForm.Setdata(selectedProduct, true); // nếu form có hàm Setdata(Class_product)

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    loadData();
                    // Gọi lại setdata với product mới (đã chỉnh sửa)
                    selectedItem.setdata(selectedProduct);

                    menu_Add.loaddata();    
                    // kiểm tra xem có đối tượng nào đang hiển thị không
                    if (manage_itemlist_Product.Controls.Count > 0 &&
                    manage_itemlist_Product.Controls[0] is Manage_itemlist detailControl)
                    {
                        detailControl.Setdata(selectedProduct);
                    }
                }
            }
        }

        private void Item_DeleteButtonClicked(object sender, EventArgs e)
        {
            Manage_item selectedItem = sender as Manage_item;
            if (selectedItem != null)
            {
                Class_product selectedProduct = selectedItem.ProductData;

                if (selectedProduct == null)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm.");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá sản phẩm này không?",
                                                      "Xác nhận xoá",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string error = "";
                    bool success = bl_product.deleteProduct(selectedProduct.Id, ref error); // Giả sử có hàm deleteProduct

                    if (success)
                    {
                        flowLayoutPanel_Product.Controls.Remove(selectedItem); // Xoá khỏi UI
                        selectedItem.Dispose(); // Giải phóng bộ nhớ

                       
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá: " + error);
                    }
                }
            }
        }


        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            ManageProduct_edit addForm = new ManageProduct_edit();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Sau khi thêm thành công, cập nhật danh sách
                loadData();
            }
        }

     
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ManageProduct_edit addForm = new ManageProduct_edit();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Sau khi thêm thành công, cập nhật danh sách
                loadData();
                menu_Add.loaddata();
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Filte_Product.Visible = !Filte_Product.Visible;
        }
        private void Filte_Product_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CategoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu chọn "All", chọn hoặc bỏ chọn tất cả
            if (sender == checkBoxAll)
            {
                bool check = checkBoxAll.Checked;

                checkBoxfastFood.Checked = check;
                checkBoxHotDrink.Checked = check;
                checkBoxColDrink.Checked = check;
                checkBoxBakery.Checked = check;
            }

            // Nếu một checkbox con bị bỏ chọn → bỏ check "All"
            if (!checkBoxfastFood.Checked || !checkBoxHotDrink.Checked || !checkBoxColDrink.Checked || !checkBoxBakery.Checked)
            {
                checkBoxAll.CheckedChanged -= CategoryCheckbox_CheckedChanged; // tránh vòng lặp
                checkBoxAll.Checked = false;
                checkBoxAll.CheckedChanged += CategoryCheckbox_CheckedChanged;
            }

            // Gọi hàm lọc mỗi khi thay đổi checkbox
            ApplyFilterByCategory();
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
                item.DeleteButtonClicked += Item_DeleteButtonClicked;

                // Thêm vào panel
                flowLayoutPanel_Product.Controls.Add(item);
            }
        }




















        private void manage_itemlist_Product_Load(object sender, EventArgs e)
        {

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ManageProduct_edit edit = new ManageProduct_edit();
            edit.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ManageProduct_edit edit = new ManageProduct_edit();
            edit.Show();
        }

      

        private void flowLayoutPanel_Product_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            ManageProduct_edit edit = new ManageProduct_edit();
            edit.Show();
        }
       

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void insert_product_Click(object sender, EventArgs e)
        {

        }

        private void Buttonadd_product_Click(object sender, EventArgs e)
        {
            ManageProduct_edit addForm = new ManageProduct_edit();

            if (addForm.ShowDialog() == DialogResult.OK)
            {

                // Sau khi thêm thành công, cập nhật danh sách
                loadData();
                menu_Add.loaddata();
            }
        }

        private void insert_product_Click_1(object sender, EventArgs e)
        {
            ManageProduct_edit addForm = new ManageProduct_edit();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                
                // Sau khi thêm thành công, cập nhật danh sách
                loadData();
                menu_Add.loaddata();



            }
        }

        private void textboxSearch_TextChanged(object sender, EventArgs e)
        {
            //string lowerKeyword = keyword.ToLower();

            //// Lấy danh sách tất cả sản phẩm từ cơ sở dữ liệu
            //List<Class_product> allProducts = bl_product.getProductList();

            //// Tạo danh sách mới chứa các sản phẩm phù hợp với từ khóa
            //List<Class_product> filteredProducts = new List<Class_product>();

            //// Duyệt từng sản phẩm trong danh sách
            //foreach (Class_product product in allProducts)
            //{
            //    // Kiểm tra nếu tên sản phẩm không null
            //    if (product.Name_Product != null)
            //    {
            //        // Chuyển tên sản phẩm về chữ thường để so sánh
            //        string productNameLower = product.Name_Product.ToLower();

            //        // Kiểm tra xem tên sản phẩm có chứa từ khóa không
            //        if (productNameLower.Contains(lowerKeyword))
            //        {
            //            // Nếu có thì thêm sản phẩm đó vào danh sách kết quả
            //            filteredProducts.Add(product);
            //        }
            //    }
            //}

            //// Gọi hàm hiển thị danh sách kết quả lọc
            //ShowProductList(filteredProducts);
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
    }
}
