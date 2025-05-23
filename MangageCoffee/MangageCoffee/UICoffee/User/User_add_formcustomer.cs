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

namespace MangageCoffee.UICoffee.User
{
    public partial class User_add_formcustomer : UserControl
    {
        public event EventHandler DetailButtonClickedFromData;
        public User_add_formcustomer()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerControls()
        {
            for (int i = 0; i < 3; i++)
            {
                var staffControl = new User_add_datacustomer();
                staffControl.DetailButtonClicked += (s, e) => DetailButtonClickedFromData?.Invoke(s, e);

                flowLayoutPanel1.Controls.Add(staffControl);
            }
        }

        // Trong lớp User_add_formcustomer.cs
        private UserBLL userBLL = new UserBLL();

        public void LoadCustomerData()
        {
            flowLayoutPanel1.Controls.Clear(); // Xóa các control cũ trước khi tải lại

            List<UserDTO> customerUsers = userBLL.GetCustomerUsers();

            foreach (UserDTO user in customerUsers)
            {
                User_add_datacustomer customerControl = new User_add_datacustomer();
                customerControl.UserData = user; // Truyền dữ liệu người dùng vào control
                                                 // Thêm các sự kiện khác nếu cần
                customerControl.Click += (s, e) => DetailButtonClickedFromData?.Invoke(user, e); // Ví dụ cho sự kiện xem chi tiết
                flowLayoutPanel1.Controls.Add(customerControl);
            }
        }
    }
}
