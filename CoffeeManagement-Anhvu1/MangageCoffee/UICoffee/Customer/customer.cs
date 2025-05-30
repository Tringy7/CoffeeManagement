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
using MangageCoffee.ADO.NET.DAL;

namespace MangageCoffee.UICoffee.Customer
{
    public partial class Customer1 : Form
    {
        UserDAL userBLL = null;
        public Customer1()
        {
            InitializeComponent();
            userBLL = new UserDAL();
        }

        private void menu_add1_Load(object sender, EventArgs e)
        {

        }

        private void deleteOderHistory_Click(object sender, EventArgs e)
        {
            try
            {
                userBLL.ResetAllUserStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi reset trạng thái người dùng: " + ex.Message);
                return;
            }

            if (Application.OpenForms["Form2"] == null)
            {
                Form2 login = new Form2();
                login.Show();
                this.Hide();
            }
            this.Close();
        }
    }
}
