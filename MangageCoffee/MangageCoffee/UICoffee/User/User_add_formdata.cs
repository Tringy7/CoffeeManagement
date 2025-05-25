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
        public event EventHandler<StaffDisplayDTO> EditButtonClickedFromData; //  Use StaffDisplayDTO
        public event EventHandler<StaffDisplayDTO> DeleteButtonClickedFromData; //  Use StaffDisplayDTO
        public event EventHandler<StaffDisplayDTO> DetailButtonClickedFromData; //  Use StaffDisplayDTO

        private UserBLL userBLL = new UserBLL();

        public User_add_formdata()
        {
            InitializeComponent();
            LoadStaffData();
        }

        public void LoadStaffData()
        {
            flowLayoutPanel1.Controls.Clear();

            List<StaffDisplayDTO> staffUsers = userBLL.GetStaffDisplayData();// Get StaffDisplayDTOs

            foreach (StaffDisplayDTO staff in staffUsers)
            {
                User_add_datastaff staffControl = new User_add_datastaff();
                staffControl.StaffData = staff; // Set StaffData
                staffControl.EditButtonClicked += (s, e) => EditButtonClickedFromData?.Invoke(this, staff); // Pass StaffDisplayDTO
                staffControl.DeleteButtonClicked += (s, e) => DeleteButtonClickedFromData?.Invoke(this, staff); // Pass StaffDisplayDTO
                staffControl.DetailButtonClicked += (s, e) => DetailButtonClickedFromData?.Invoke(this, staff); // Pass StaffDisplayDTO
                flowLayoutPanel1.Controls.Add(staffControl);
            }
        }
    }

 }
