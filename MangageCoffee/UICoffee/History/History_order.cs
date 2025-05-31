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

        //public void setdata(Class_Oder history)
        //{
        //    oderItem = history;

        //    CustomerDisplayDTO customer = bl_history.GetCustomerInfoByCustomerID(history.CustomerID);
        //    Fullname.Text = customer.FullName;
        //    Id.Text = customer.CustomerID.ToString();
        //    Date.Text = history.OderDate.ToString("dd/MM/yyyy");
        //    Time.Text = history.OderTime.ToString();
        //    totalMoney.Text = history.TotalAmount.ToString();

        //    List<Class_Oder> listOder = bl_history.GetListOderByCustomerID(history.CustomerID);
        //    if (listOder != null && listOder.Count > 0)
        //    {
        //        foreach (Class_Oder oderItem in listOder)
        //        {
        //            History_order_item history_Order_Item = new History_order_item();
        //            history_Order_Item.setData(oderItem);
        //            flowLayoutPanelAdd_Oder.Controls.Add(history_Order_Item);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Không có đơn hàng nào của khách hàng này.");
        //    }

        //}
        public void setdata(List<Class_Oder> orders)
        {
            if (orders == null || orders.Count == 0)
            {
                MessageBox.Show("Không có đơn hàng nào.");
                return;
            }

            // Lấy thông tin chung từ đơn hàng đầu tiên trong nhóm
            Class_Oder firstOrder = orders[0];
            oderItem = firstOrder;

            // Lấy thông tin khách hàng
            CustomerDisplayDTO customer = bl_history.GetCustomerInfoByCustomerID(firstOrder.CustomerID);
            if (customer != null)
            {
                Fullname.Text = customer.FullName;
                Id.Text = customer.CustomerID.ToString();
            }

            // Ngày giờ mua hàng (dùng chung cho nhóm)
            Date.Text = firstOrder.OderDate.ToString("dd/MM/yyyy");
            Time.Text = firstOrder.OderTime.ToString();

            // Tổng tiền của nhóm sản phẩm (cộng tất cả lại)
            double total = orders.Sum(o => o.TotalAmount);
            totalMoney.Text = total.ToString("N0"); // định dạng tiền tệ nếu muốn

            // Hiển thị danh sách sản phẩm
            flowLayoutPanelAdd_Oder.Controls.Clear(); // tránh trùng nếu gọi lại
            foreach (Class_Oder order in orders)
            {
                History_order_item history_Order_Item = new History_order_item();
                history_Order_Item.setData(order);
                flowLayoutPanelAdd_Oder.Controls.Add(history_Order_Item);
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
