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
    public partial class AddForm : Form
    {
        private UserBLL userBLL = new UserBLL();
        public AddForm()
        {
            InitializeComponent();
        }

        private void chbNam_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNam.Checked)
            {
                chbNu.Checked = false;
                chbKhac.Checked = false;
            }
        }

        private void chbNu_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNu.Checked)
            {
                chbNam.Checked = false;
                chbKhac.Checked = false;
            }
        }

        private void chbKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chbKhac.Checked)
            {
                chbNam.Checked = false;
                chbNu.Checked = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; //  Signal cancellation to User_add.cs
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Gather the staff data
            string fullName = txtHoTen.Text;
            string phone = txtSDT.Text;
            string gender = "";
            if (chbNam.Checked) gender = "Nam";
            else if (chbNu.Checked) gender = "Nữ";
            else if (chbKhac.Checked) gender = "Khác";
            DateTime dateOfBirth = dtpNgaySinh.Value;
            string position = cbbChucVu.SelectedItem?.ToString();
            decimal? salary = decimal.TryParse(txtLuong.Text, out decimal parsedSalary) ? parsedSalary : (decimal?)null;
            DateTime hireDate = dtpHireDate.Value;
            string username = txtUsername.Text; // Get username from txtUsername
            string password = txtPassword.Text; // Get password from txtPassword


            // Create a new UserDTO and StaffDisplayDTO
            UserDTO newUser = new UserDTO
            {
                Username = username, // Use the provided username
                Password = password, // Use the provided password
                Role = "Staff", // Set the role to Staff
                FullName = fullName,
                Phone = phone,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Position = position,
                Salary = salary,
                HireDate = hireDate,
                ImagePath = _newImagePath
            };


            // Call the BLL to add the new staff member
            if (userBLL.AddStaff(newUser)) // You'll need to implement AddStaff in BLL/DAL
            {
                Notice mess = new Notice("Add employee successfully!");
                mess.ShowDialog();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Notice mess = new Notice("Cannot add staff!");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
