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
using MangageCoffee.UICoffee.User; 

namespace MangageCoffee.UICoffee
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            LoadUserInfo();
            LoadStaffAndCustomerCounts();
        }

        private UserBLL userBLL = new UserBLL();

        private void LoadUserInfo()
        {
            UserDTO user = userBLL.GetLoggedInUserInfo(); 

            if (user == null)
            {
                MessageBox.Show("Không có người dùng đang đăng nhập.");
                return;
            }

            lblHoTen.Text = user.FullName ?? "";
            lblRole.Text = user.Role ?? "";
            lblGender.Text = user.Gender ?? "";
            lblDate.Text = user.DateOfBirth?.ToString("dd/MM/yyyy") ?? "";
            lblSDT.Text = user.Phone ?? "";
            Console.WriteLine($"Home.LoadUserInfo - KPI: {user?.KPI}"); // Add this
            cpbKPI.Value = user.KPI ?? 0;
            lblKPI.Text = (user.KPI ?? 0).ToString() + "%";

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
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}\nĐường dẫn: {fullImagePath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Không tìm thấy ảnh: {fullImagePath} và không có ảnh mặc định tại {defaultImagePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserDTO loggedInAdmin = userBLL.GetLoggedInUserInfo(); // Get the current Admin's data
            if (loggedInAdmin != null && loggedInAdmin.Role == "Admin")
            {
                EditAdminForm editForm = new EditAdminForm(loggedInAdmin);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUserInfo(); // Refresh Home.cs after editing
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa thông tin này.");
            }
        }

        private void LoadStaffAndCustomerCounts()
        {
            lblTongNV.Text = userBLL.GetStaffCount().ToString();
            lblTongKH.Text = userBLL.GetCustomerCount().ToString();
            lblTongSP.Text = userBLL.GetProductCount().ToString();
        }
    }
}
