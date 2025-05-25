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

namespace MangageCoffee.UICoffee.User
{
    public partial class EditAdminForm : Form
    {
        private UserBLL userBLL = new UserBLL();
        private UserDTO _adminToEdit;
        public EditAdminForm(UserDTO adminToEdit)
        {
            InitializeComponent();
            _adminToEdit = adminToEdit;
            LoadAdminData();
        }

        private void LoadAdminData()
        {
            txtUsername.Text = _adminToEdit.Username;
            txtPassword.Text = _adminToEdit.Password; 
            txtHoTen.Text = _adminToEdit.FullName;
            txtSDT.Text = _adminToEdit.Phone;
            chbNam.Checked = _adminToEdit.Gender == "Nam";
            chbNu.Checked = _adminToEdit.Gender == "Nữ";
            chbKhac.Checked = _adminToEdit.Gender == "Khác";
            dtpNgaySinh.Value = _adminToEdit.DateOfBirth ?? DateTime.Now;

            LoadAvatar();
        }

        private void LoadAvatar()
        {
            if (!string.IsNullOrEmpty(_adminToEdit.ImagePath))
            {
                string imagePath = Path.Combine("Images", _adminToEdit.ImagePath);
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


        private string _newImagePath = null;
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private void btnAvatar_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;)|*.png;*.jpg;*.jpeg;*.gif;";
            openFileDialog.Title = "Chọn ảnh đại diện";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(selectedFilePath);
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    string destPath = Path.Combine(imagesFolder, fileName);

                    if (!File.Exists(destPath))
                    {
                        File.Copy(selectedFilePath, destPath);
                    }

                    ptbAvatar.Image = Image.FromFile(destPath);

                    _newImagePath = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _adminToEdit.Username = txtUsername.Text;
            if (!string.IsNullOrEmpty(txtPassword.Text)) 
            {
                _adminToEdit.Password = txtPassword.Text; 
            }
            _adminToEdit.FullName = txtHoTen.Text;
            _adminToEdit.Phone = txtSDT.Text;
            if (chbNam.Checked) _adminToEdit.Gender = "Nam";
            else if (chbNu.Checked) _adminToEdit.Gender = "Nữ";
            else _adminToEdit.Gender = "Khác";
            _adminToEdit.DateOfBirth = dtpNgaySinh.Value;

            if (!string.IsNullOrEmpty(_newImagePath))
            {
                _adminToEdit.ImagePath = _newImagePath;
            }

            UserDTO userToUpdate = new UserDTO
            {
                UserID = _adminToEdit.UserID,
                Username = _adminToEdit.Username,
                Password = _adminToEdit.Password, 
                FullName = _adminToEdit.FullName,
                Phone = _adminToEdit.Phone,
                Gender = _adminToEdit.Gender,
                DateOfBirth = _adminToEdit.DateOfBirth,
                ImagePath = _adminToEdit.ImagePath
            };

            if (userBLL.UpdateAdmin(userToUpdate)) 
            {
                MessageBox.Show("Admin information updated successfully.");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update Admin information.");
            }
        }
    }
}
