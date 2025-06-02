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
using MangageCoffee.UICoffee.Untils;

namespace MangageCoffee.UICoffee.User
{
    public partial class EditForm : Form
    {
        private UserBLL userBLL = new UserBLL();
        private StaffDisplayDTO _staffToEdit;
        public EditForm(StaffDisplayDTO staffToEdit)
        {
            InitializeComponent();
            _staffToEdit = staffToEdit;
            LoadStaffData();
        }

        private void LoadStaffData()
        {

            txtHoTen.Text = _staffToEdit.FullName;
            txtSDT.Text = _staffToEdit.Phone;

            chbNam.Checked = _staffToEdit.Gender == "Nam";
            chbNu.Checked = _staffToEdit.Gender == "Nữ";
            chbKhac.Checked = _staffToEdit.Gender == "Khác";

            dtpNgaySinh.Value = _staffToEdit.DateOfBirth ?? DateTime.Now;

            //  Handle Position (ComboBox)
            cbbChucVu.SelectedItem = _staffToEdit.Position;

            txtLuong.Text = _staffToEdit.Salary?.ToString() ?? "";

            //  Load the image (if any)
            if (!string.IsNullOrEmpty(_staffToEdit.ImagePath))
            {
                string imagePath = Path.Combine("Images", _staffToEdit.ImagePath);
                if (File.Exists(imagePath))
                {
                    ptbAvatar.Image = Image.FromFile(imagePath);
                }
                else
                {
                    ptbAvatar.Image = Properties.Resources._default;
                }
            }
            else
            {
                ptbAvatar.Image = Properties.Resources._default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; //  Signal cancellation to User_add.cs
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Gather the edited data
            _staffToEdit.FullName = txtHoTen.Text;
            _staffToEdit.Phone = txtSDT.Text;


            // Handle Gender (Checkboxes)
            if (chbNam.Checked)
            {
                _staffToEdit.Gender = "Nam";
            }
            else if (chbNu.Checked)
            {
                _staffToEdit.Gender = "Nữ";
            }
            else if (chbKhac.Checked)
            {
                _staffToEdit.Gender = "Khác";
            }
            else
            {
                _staffToEdit.Gender = null;
            }


            _staffToEdit.DateOfBirth = dtpNgaySinh.Value;
            _staffToEdit.Position = cbbChucVu.SelectedItem?.ToString();
            _staffToEdit.Salary = decimal.TryParse(txtLuong.Text, out decimal salary) ? salary : (decimal?)null;


            // Update ImagePath
            if (!string.IsNullOrEmpty(_newImagePath))
            {
                _staffToEdit.ImagePath = _newImagePath; 
            }


            UserDTO userToUpdate = new UserDTO
            {
                UserID = _staffToEdit.UserID,
                FullName = _staffToEdit.FullName,
                Phone = _staffToEdit.Phone,
                Gender = _staffToEdit.Gender,
                DateOfBirth = _staffToEdit.DateOfBirth,
                Position = _staffToEdit.Position,
                Salary = _staffToEdit.Salary,
                ImagePath = _staffToEdit.ImagePath,
                HireDate = _staffToEdit.HireDate
            };


            if (userBLL.UpdateUser(userToUpdate))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Notice mess = new Notice("Unable to update information!");
                mess.ShowDialog();
            }
        }


        private string _newImagePath = null;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private void btnAvatar_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;)|*.png;*.jpg;*.jpeg;*.gif;";
            openFileDialog.Title = "Select profile picture";

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
                    ptbAvatar.Image = Image.FromFile(destPath);

                    // Lưu tên ảnh để ghi vào ImagePath
                    _newImagePath = fileName;
                }
                catch (Exception ex)
                {
                    Notice mess = new Notice("Error loading image!");
                    mess.ShowDialog();
                }
            }
        }
    }
    
}
