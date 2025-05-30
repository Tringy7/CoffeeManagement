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
using System.IO;

namespace MangageCoffee.UICoffee.ManageDishes
{
    public partial class ManageDishes_edit : Form
    {
        private bool isEdit = false;
        public Class_product tempProduct;
        public BL_Product bl_product = new BL_Product();
        public ManageDishes_edit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void Setdata(Class_product product, bool isEditMode)
        {
            tempProduct = product;
            isEdit = isEditMode;

            TxtId.Text = product.OriginalPrice.ToString();
            Txtname.Text = product.Name_Product;
            TxtQuantity.Text = product.Quantity.ToString();
            TxtStatus.Text = product.Status.ToString();
            TxtType.Text = product.Category.ToString();
            Txtcost.Text = product.Price.ToString();
            if (isEdit && !string.IsNullOrEmpty(product.ImagePath))
            {
                LoadProductImage(product.ImagePath);
            }
        }
        private void LoadProductImage(string imageFileName)
        {
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                string imageFullPath = Path.Combine(imagesFolder, imageFileName);
                if (File.Exists(imageFullPath))
                {
                    ptbImage.Image = Image.FromFile(imageFullPath);
                    ptbImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("Image file not found: " + imageFullPath);
                    ptbImage.Image = null; // Clear the PictureBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
                ptbImage.Image = null; // Clear the PictureBox
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {

                string error = "không thêm sản phẩm được";
                bool success;


                if (isEdit)
                {

                    tempProduct.Name_Product = Txtname.Text;
                    tempProduct.Quantity = int.Parse(TxtQuantity.Text);
                    tempProduct.Price = double.Parse(Txtcost.Text);
                    tempProduct.Category = TxtType.SelectedItem?.ToString();  // Dùng ?. để tránh lỗi null
                    tempProduct.Status = TxtStatus.SelectedItem?.ToString();
                    tempProduct.OriginalPrice = double.Parse(TxtId.Text);
                    tempProduct.ImagePath = _newImagePath ?? tempProduct.ImagePath;
                    success = bl_product.updateProduct(tempProduct, ref error);
                }
                else
                {
                    Class_product newProduct = new Class_product();
                    newProduct.Name_Product = Txtname.Text;
                    newProduct.Quantity = int.Parse(TxtQuantity.Text);
                    newProduct.Price = double.Parse(Txtcost.Text);
                    newProduct.Category = TxtType.SelectedItem?.ToString();  // Dùng ?. để tránh lỗi null
                    newProduct.Status = TxtStatus.SelectedItem?.ToString();
                    newProduct.CreatedBy = 1;
                    newProduct.OriginalPrice = double.Parse(TxtId.Text);
                    newProduct.ImagePath = _newImagePath;
                    success = bl_product.addNewProduct(newProduct, ref error);
                }

                if (success)
                {
                    MessageBox.Show(isEdit ? "Cập nhật thành công!" : "Thêm sản phẩm thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                    MessageBox.Show(error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageDishes_edit_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string _newImagePath = null;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private void btnHome_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;)|*.png;*.jpg;*.jpeg;*.gif;";
            openFileDialog.Title = "Chọn ảnh sản phẩm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(selectedFilePath);
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    string destPath = Path.Combine(imagesFolder, fileName);

                    // Copy ảnh nếu nó chưa có trong thư mục Images
                    if (!File.Exists(destPath))
                    {
                        File.Copy(selectedFilePath, destPath);
                    }

                    // Hiển thị ảnh lên PictureBox
                    ptbImage.Image = Image.FromFile(destPath);
                        ptbImage.SizeMode = PictureBoxSizeMode.Zoom;

                    // Lưu tên ảnh để ghi vào ImagePath
                    _newImagePath = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        } 

    }
}
