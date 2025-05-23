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
    public partial class User_add_formdata : UserControl
    {
        public event EventHandler EditButtonClickedFromData;
        public event EventHandler DeleteButtonClickedFromData;
        public event EventHandler DetailButtonClickedFromData;

        public User_add_formdata()
        {
            InitializeComponent();
            LoadStaffData();
        }

        private void LoadStaffControls()
        {
            for (int i = 0; i < 3; i++) 
            {
                var staffControl = new User_add_datastaff();
                staffControl.EditButtonClicked += (s, e) => EditButtonClickedFromData?.Invoke(s, e);
                staffControl.DeleteButtonClicked += (s, e) => DeleteButtonClickedFromData?.Invoke(s, e);
                staffControl.DetailButtonClicked += (s, e) => DetailButtonClickedFromData?.Invoke(s, e);

                flowLayoutPanel1.Controls.Add(staffControl); 
            }
        }

        // Trong lớp User_add_formdata.cs
        private UserBLL userBLL = new UserBLL();

        public void LoadStaffData()
        {
            flowLayoutPanel1.Controls.Clear(); // Xóa các control cũ trước khi tải lại

            List<UserDTO> staffUsers = userBLL.GetStaffUsers();

            foreach (UserDTO user in staffUsers)
            {
                User_add_datastaff staffControl = new User_add_datastaff();
                staffControl.UserData = user; // Truyền dữ liệu người dùng vào control
                staffControl.EditButtonClicked += (s, e) => EditButtonClickedFromData?.Invoke(user, e);
                staffControl.DeleteButtonClicked += (s, e) => DeleteButtonClickedFromData?.Invoke(user, e);
                // Thêm các sự kiện khác nếu cần
                flowLayoutPanel1.Controls.Add(staffControl);
            }
        }
    }

}
