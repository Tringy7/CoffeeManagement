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

namespace MangageCoffee.UICoffee
{
    public partial class User_add_datastaff : UserControl
    {
        public event EventHandler EditButtonClicked;
        public event EventHandler DeleteButtonClicked;
        public event EventHandler DetailButtonClicked;

        public User_add_datastaff()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            DetailButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public UserDTO UserData
        {
            set
            {
                lblID.Text = value.UserID.ToString();
                lblHo.Text = value.FullName; // Hoặc lblTen tùy thuộc vào cách bạn lưu FullName
                lblGioiTinh.Text = value.Gender;
                lblNgaySinh.Text = value.DateOfBirth?.ToString("dd/MM/yyyy");
                lblSDT.Text = value.Phone;
                lblVaiTro.Text = value.Role;
                // Load ảnh nếu có
                // string imagePath = Path.Combine("Images", value.ImagePath); // Giả sử thư mục Images ngang cấp với file exe
                // if (File.Exists(imagePath))
                // {
                //     ptbAvatar.Image = Image.FromFile(imagePath);
                // }
                // else
                // {
                //     ptbAvatar.Image = Properties.Resources._default; // Ảnh mặc định
                // }
            }
        }

        // Chỉnh sửa sự kiện click nếu bạn muốn truyền UserID khi click
        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    // Lấy UserID từ lblID.Text hoặc từ thuộc tính UserData
        //    // int userId = int.Parse(lblID.Text); 
        //    // UserDTO userToEdit = new UserBLL().GetUserDetails(new UserDTO { UserID = userId, Role = "Staff" });
        //    // EditButtonClicked?.Invoke(userToEdit, EventArgs.Empty); 
        //}
        //// Tương tự cho btnDelete và guna2Button1 (nút xem chi tiết)
    }

}
