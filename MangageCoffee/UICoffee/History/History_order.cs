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

namespace MangageCoffee.UICoffee.History
{
    public partial class History_order : UserControl
    {
        BL_history bl_history = null;
        Class_Oder oderItem = null;
        public History_order()
        {
            bl_history = new BL_history();
            oderItem = new Class_Oder();
            InitializeComponent();
          
        }

        public void setdata(Class_Oder history)
        {
            oderItem = history;

            CustomerDisplayDTO customer = bl_history.GetCustomerInfoByCustomerID(history.CustomerID);
            Fullname.Text = customer.FullName;
            Id.Text = customer.CustomerID.ToString();
            Date.Text = history.OderDate.ToString("dd/MM/yyyy");
            Time.Text = history.OderTime.ToString();
            totalMoney.Text = history.TotalAmount.ToString();

            List<Class_Oder> listOder = bl_history.GetListOderByCustomerID(history.CustomerID);
            //MessageBox.Show("Số lượng đơn hàng: " + listOder.Count.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (listOder != null && listOder.Count > 0)
            {
                foreach (Class_Oder oderItem in listOder)
                {
                    History_order_item history_Order_Item = new History_order_item();
                    history_Order_Item.setData(oderItem);
                    flowLayoutPanelAdd_Oder.Controls.Add(history_Order_Item);
                }
            }
            else
            {
                MessageBox.Show("Không có đơn hàng nào của khách hàng này.");
            }

        }
        //public delegate void DeleteOrderHandler();
        //public event DeleteOrderHandler OnOrderDeleted;

        //private void deleteOderHistory_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả đơn hàng của khách hàng này không?",
        //                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        //    if (result == DialogResult.Yes)
        //    {
        //        string error = " "; 
        //        MessageBox.Show("odderritme " + oderItem.ItemID);
        //        bool isDeleted = bl_history.DeleteOrderByOderID(oderItem.OderId,ref error);

        //        if (isDeleted)
        //        {
        //            MessageBox.Show("Xóa đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            // Gọi event thông báo lên form cha để load lại dữ liệu
        //            OnOrderDeleted?.Invoke();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Xóa đơn hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deleteOderHistory_Click(object sender, EventArgs e)
        {
            string error = " ";
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá lịch sử đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = bl_history.DeleteOrderByOderID(oderItem.OderId,ref error);

                if (success)
                {
                    MessageBox.Show("xoá đơn hàng thành công.");
                    this.Parent.Controls.Remove(this); // Xóa UserControl này khỏi giao diện
                }
                else
                {
                    MessageBox.Show("xoá đơn hàng thất bại.");
                }
            }
        }

    }
}
