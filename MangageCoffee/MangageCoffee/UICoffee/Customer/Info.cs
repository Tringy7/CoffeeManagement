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
using MangageCoffee.UICoffee.Untils;
using System.IO;

namespace MangageCoffee.UICoffee.Customer
{
    public partial class Info : Form
    {
        private UserBLL userBLL = new UserBLL();
        public Info()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadUserInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string _newImagePath = null;
        private void btnSave_Click(object sender, EventArgs e)
        {
            UserDTO user = userBLL.GetLoggedInUserInfo();

            user.FullName = txtHoTen.Text;
            user.Phone = txtSDT.Text;
            if (chbNam.Checked) user.Gender = "Nam";
            else if (chbNu.Checked) user.Gender = "Nữ";
            else user.Gender = "Khác";
            user.DateOfBirth = dtpNgaySinh.Value;

            if (!string.IsNullOrEmpty(_newImagePath))
            {
                user.ImagePath = _newImagePath;
            }

            UserDTO customer = new UserDTO
            {
                CustomerID = user.CustomerID,
                FullName = user.FullName,
                Phone = user.Phone,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                ImagePath = user.ImagePath
            };

            if (userBLL.UpdateCustomer(customer))
            {
                Notice mess = new Notice("Updated successfully.!");

                mess.ShowDialog();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Notice mess = new Notice("Update failedy.!");
                mess.ShowDialog();
            }
        }

        
        private void LoadUserInfo()
        {
            UserDTO user = userBLL.GetLoggedInUserInfo();

            if (user == null)
            {
                Notice mess = new Notice("No users are logged in!");
                mess.ShowDialog();
                return;
            }

            txtHoTen.Text = user.FullName ?? "";
            chbNam.Checked = user.Gender == "Nam";
            chbNu.Checked = user.Gender == "Nữ";
            chbKhac.Checked = user.Gender == "Khác";
            dtpNgaySinh.Value = user.DateOfBirth ?? DateTime.Now;
            txtSDT.Text = user.Phone ?? "";

            string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string fullImagePath = Path.Combine(imageFolderPath, user.ImagePath ?? "default.png");

            if (File.Exists(fullImagePath))
            {
                try
                {
                    using (Image img = Image.FromFile(fullImagePath))
                    {
                        ptbAvatar.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    Notice mess = new Notice("Error loading image!");
                    mess.ShowDialog();
                    ptbAvatar.Image = null;
                }
            }
            else
            {
                string defaultImagePath = Path.Combine(imageFolderPath, "default.png");
                if (File.Exists(defaultImagePath))
                {
                    ptbAvatar.Image = Image.FromFile(defaultImagePath);
                }
                else
                {
                    ptbAvatar.Image = null;
                    Notice mess = new Notice("Error loading image!");
                    mess.ShowDialog();
                }
            }
        }
    }
}
