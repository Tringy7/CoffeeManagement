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
        public event EventHandler<CustomerDisplayDTO> DetailButtonClickedFromData;
        public User_add_formcustomer()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        // Trong lớp User_add_formcustomer.cs
        private UserBLL userBLL = new UserBLL();

        public void LoadCustomerData()
        {
            flowLayoutPanel1.Controls.Clear();

            List<CustomerDisplayDTO> customerUsers = userBLL.GetCustomerDisplayData(); //  Get CustomerDisplayDTOs

            foreach (CustomerDisplayDTO customer in customerUsers)
            {
                User_add_datacustomer customerControl = new User_add_datacustomer();
                customerControl.CustomerData = customer; //  Set CustomerData
                customerControl.DetailButtonClicked += (s, e) => DetailButtonClickedFromData?.Invoke(this, customer); //  Pass CustomerDisplayDTO
                flowLayoutPanel1.Controls.Add(customerControl);
            }
        }
    }
}
