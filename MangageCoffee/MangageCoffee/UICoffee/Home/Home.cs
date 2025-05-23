using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // Thêm dòng này nếu chưa có
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Thêm dòng này nếu chưa có
using MangageCoffee.ADO.NET.BLL;
using MangageCoffee.DTO;
using System.IO; // Thêm dòng này để sử dụng Path.Combine, File.Exists

namespace MangageCoffee.UICoffee
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            LoadUserInfo();
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

            string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string fullImagePath = Path.Combine(imageFolderPath, user.ImagePath ?? "default.png"); // Sử dụng ảnh mặc định nếu ImagePath là null

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
                    ptbAvatar.Image = null; // Không có ảnh mặc định
                    MessageBox.Show($"Không tìm thấy ảnh: {fullImagePath} và không có ảnh mặc định tại {defaultImagePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
