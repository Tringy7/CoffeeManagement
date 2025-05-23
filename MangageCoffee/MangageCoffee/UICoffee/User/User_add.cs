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
using MangageCoffee.UICoffee.User;

namespace MangageCoffee.UICoffee
{
    public partial class User_add : UserControl
    {
        // Trong lớp User_add.cs
        public User_add()
        {
            InitializeComponent();
            user_add_formdata1.EditButtonClickedFromData += User_add_edit_ButtonClicked;
            user_add_formdata1.DeleteButtonClickedFromData += User_add_delete_ButtonClicked;
            user_add_formcustomer1.DetailButtonClickedFromData += Customer_see_detail;
            user_add_formdata1.DetailButtonClickedFromData += User_add_detail_Buttonclicked;

            // Tải dữ liệu mặc định khi User_add được khởi tạo, ví dụ hiển thị Staff trước
            btnStaffs_Click(this, EventArgs.Empty);
        }

        private void btnStaffs_Click(object sender, EventArgs e)
        {
            label4.Text = "STAFF"; // Cập nhật tiêu đề
            user_add_formdata1.BringToFront(); // Đưa form staff lên trên
            user_add_formdata1.LoadStaffData(); // Tải dữ liệu staff
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            label4.Text = "CUSTOMER"; // Cập nhật tiêu đề
            user_add_formcustomer1.BringToFront(); // Đưa form customer lên trên
            user_add_formcustomer1.LoadCustomerData(); // Tải dữ liệu customer
        }

        // Các phương thức xử lý sự kiện
        private void User_add_edit_ButtonClicked(object sender, EventArgs e)
        {
            //UserDTO userToEdit = sender as UserDTO; // Ép kiểu sender về UserDTO
            //if (userToEdit != null)
            //{
            //    User_add_editprofile editProfile = new User_add_editprofile(userToEdit);
            //    editProfile.ShowDialog(); // Hiển thị form chỉnh sửa
            //                              // Sau khi chỉnh sửa xong, cần refresh lại danh sách
            //    if (label4.Text == "STAFF") // Kiểm tra xem đang ở tab nào để refresh
            //    {
            //        user_add_formdata1.LoadStaffData();
            //    }
            //}
        }

        private void User_add_delete_ButtonClicked(object sender, EventArgs e)
        {
            //UserDTO userToDelete = sender as UserDTO;
            //if (userToDelete != null)
            //{
            //    DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa người dùng {userToDelete.FullName}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (confirm == DialogResult.Yes)
            //    {
            //        UserBLL userBLL = new UserBLL();
            //        if (userBLL.DeleteUser(userToDelete.UserID)) // Cần bổ sung phương thức DeleteUser vào UserBLL và UserDAL
            //        {
            MessageBox.Show("Xóa người dùng thành công.");
            //            if (label4.Text == "STAFF")
            //            {
            //                user_add_formdata1.LoadStaffData();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Không thể xóa người dùng.");
            //        }
            //    }
            //}
        }

        private void Customer_see_detail(object sender, EventArgs e)
        {
            UserDTO customerDetail = sender as UserDTO;
            if (customerDetail != null)
            {
                // Hiển thị form chi tiết khách hàng hoặc các thông tin khác
                MessageBox.Show($"Chi tiết khách hàng: {customerDetail.FullName}, Email: {customerDetail.Email}, TotalOrders: {customerDetail.TotalOrders}", "Thông tin khách hàng");
            }
        }

        private void User_add_detail_Buttonclicked(object sender, EventArgs e)
        {
            UserDTO userDetail = sender as UserDTO;
            if (userDetail != null)
            {
                // Hiển thị form chi tiết người dùng hoặc các thông tin khác
                MessageBox.Show($"Chi tiết người dùng: {userDetail.FullName}, Vai trò: {userDetail.Role}", "Thông tin người dùng");
            }
        }
    }
}
