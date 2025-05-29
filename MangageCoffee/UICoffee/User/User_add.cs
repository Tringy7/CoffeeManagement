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
using System.IO;
using MangageCoffee.ADO.NET.DAL;

namespace MangageCoffee.UICoffee
{
    public partial class User_add : UserControl
    {
        private UserBLL userBLL = new UserBLL();
        public User_add()
        {
            InitializeComponent();
            user_add_formdata1.EditButtonClickedFromData += User_add_edit_ButtonClicked_Staff;
            user_add_formdata1.DeleteButtonClickedFromData += User_add_delete_ButtonClicked_Staff;
            user_add_formdata1.DetailButtonClickedFromData += User_add_detail_ButtonClicked_Staff;

            user_add_formcustomer1.DetailButtonClickedFromData += User_add_detail_ButtonClicked_Customer;

            btnStaffs_Click(this, EventArgs.Empty);
        }

        private void btnStaffs_Click(object sender, EventArgs e)
        {
            label4.Text = "STAFF"; // Cập nhật tiêu đề
            user_add_formdata1.BringToFront(); // Đưa form staff lên trên
            user_add_formdata1.LoadStaffData(); // Tải dữ liệu staff
            this.ptbAdd.Visible = true; // Hiển thị nút thêm người dùng
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            label4.Text = "CUSTOMER"; // Cập nhật tiêu đề
            user_add_formcustomer1.BringToFront(); // Đưa form customer lên trên
            user_add_formcustomer1.LoadCustomerData(); // Tải dữ liệu customer
            this.ptbAdd.Visible = false; // Ẩn nút thêm người dùng
        }

        // Các phương thức xử lý sự kiện
        private void User_add_edit_ButtonClicked_Staff(object sender, StaffDisplayDTO e)
        {
            StaffDisplayDTO staffToEdit = e;

            EditForm editForm = new EditForm(staffToEdit);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Chỉnh sửa người dùng thành công.");
                user_add_formdata1.LoadStaffData(); // Refresh the staff data
            }
            else
            {
                MessageBox.Show("Chỉnh sửa người dùng bị hủy bỏ.");
            }
        }

        private void User_add_delete_ButtonClicked_Staff(object sender, StaffDisplayDTO e)
        {

            if (e != null)
            {
                DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa người dùng {e.FullName}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    userBLL.SetUserAvailability(e.UserID, false); // Cập nhật Available = false
                    MessageBox.Show("Xóa người dùng thành công.");
                    user_add_formdata1.LoadStaffData(); // Refresh Staff Data
                }
                else
                {
                    MessageBox.Show("Hủy thao tác");
                }
            }

        }

        private void User_add_detail_ButtonClicked_Staff(object sender, StaffDisplayDTO e)
        {
            ShowStaffDetailsForm(e);
        }

        private void User_add_detail_ButtonClicked_Customer(object sender, CustomerDisplayDTO e)
        {
            ShowCustomerDetailsForm(e);
        }

        private void ShowStaffDetailsForm(StaffDisplayDTO staff) 
        {
            StaffDetails staffDetailsForm = new StaffDetails();

            staffDetailsForm.lblID.Text = staff.StaffID;
            staffDetailsForm.lblHoTen.Text = staff.FullName;
            staffDetailsForm.lblChucVu.Text = staff.Position;
            staffDetailsForm.lblGioiTinh.Text = staff.Gender;
            staffDetailsForm.lblSDT.Text = staff.Phone;
            staffDetailsForm.lblNgaySinh.Text = staff.DateOfBirth.HasValue ? staff.DateOfBirth.Value.ToString("dd/MM/yyyy") : "";
            staffDetailsForm.lblLuong.Text = staff.Salary.HasValue ? staff.Salary.Value.ToString() : "";
            staffDetailsForm.lblNgayLam.Text = staff.HireDate.HasValue ? staff.HireDate.Value.ToString("dd/MM/yyyy") : "";

            string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string fullImagePath = Path.Combine(imageFolderPath, staff.ImagePath ?? "default.png");

            if (File.Exists(fullImagePath))
            {
                try
                {
                    using (Image img = Image.FromFile(fullImagePath))
                    {
                        staffDetailsForm.ptbAvatar.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}\nĐường dẫn: {fullImagePath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    staffDetailsForm.ptbAvatar.Image = null;
                }
            }
            else
            {
                string defaultImagePath = Path.Combine(imageFolderPath, "default.png");
                if (File.Exists(defaultImagePath))
                {
                    staffDetailsForm.ptbAvatar.Image = Image.FromFile(defaultImagePath);
                }
                else
                {
                    staffDetailsForm.ptbAvatar.Image = null;
                    MessageBox.Show($"Không tìm thấy ảnh: {fullImagePath} và không có ảnh mặc định tại {defaultImagePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            staffDetailsForm.ShowDialog(); //  Show the StaffDetails Form as a dialog
        }

        private void ShowCustomerDetailsForm(CustomerDisplayDTO customer)
        {
            CustomerDetail customerDetail = new CustomerDetail();

            customerDetail.lblID.Text = customer.CustomerID.ToString();
            customerDetail.lblHoTen.Text = customer.FullName;
            customerDetail.lblDon.Text = customer.TotalOrders.HasValue ? customer.TotalOrders.Value.ToString() : "";
            customerDetail.lblGioiTinh.Text = customer.Gender;
            customerDetail.lblSDT.Text = customer.Phone;
            customerDetail.lblNgaySinh.Text = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value.ToString("dd/MM/yyyy") : "";
            customerDetail.lblFeedBack.Text = customer.TotalFeedbacks.HasValue ? customer.TotalFeedbacks.Value.ToString() : "";
            customerDetail.lblTienChi.Text = customer.TotalSpent.HasValue ? customer.TotalSpent.Value.ToString("C") : ""; 

            string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string fullImagePath = Path.Combine(imageFolderPath, customer.ImagePath ?? "default.png");

            if (File.Exists(fullImagePath))
            {
                try
                {
                    using (Image img = Image.FromFile(fullImagePath))
                    {
                        customerDetail.ptbAvatar.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}\nĐường dẫn: {fullImagePath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerDetail.ptbAvatar.Image = null;
                }
            }
            else
            {
                string defaultImagePath = Path.Combine(imageFolderPath, "default.png");
                if (File.Exists(defaultImagePath))
                {
                    customerDetail.ptbAvatar.Image = Image.FromFile(defaultImagePath);
                }
                else
                {
                    customerDetail.ptbAvatar.Image = null;
                    MessageBox.Show($"Không tìm thấy ảnh: {fullImagePath} và không có ảnh mặc định tại {defaultImagePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            customerDetail.ShowDialog(); // Show the CustomerDetail Form as a dialog  
        }

        private void ptbAdd_Click(object sender, EventArgs e)
        {

            
        }

        private void btnAvatar_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Chỉnh sửa người dùng thành công.");
                user_add_formdata1.LoadStaffData();
            }
            else
            {
                MessageBox.Show("Chỉnh sửa người dùng bị hủy bỏ.");
            }
        }
    }
}
