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

        public StaffDisplayDTO StaffData //  Use StaffDisplayDTO
        {
            set
            {
                lblID.Text = value.StaffID.ToString();
                lblHo.Text = value.FullName;
                lblGioiTinh.Text = value.Gender;
                lblNgaySinh.Text = value.DateOfBirth?.ToString("dd/MM/yyyy");
                lblSDT.Text = value.Phone;
                lblVaiTro.Text = value.Position;
            }
        }
    }

}
