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
using MangageCoffee.UICoffee.Untils;

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

        public void setdata(List<Class_Oder> orders)
        {
            if (orders == null || orders.Count == 0)
            {
                Notice mess = new Notice("No orders yet!");
                mess.ShowDialog();
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




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deleteOderHistory_Click(object sender, EventArgs e)
        {
            string error = " ";
            Mess mess1 = new Mess();
            mess1.ShowDialog();

            if (mess1.Proceed)
            {
                bool success = bl_history.DeleteOrderByOderID(oderItem.OderId,ref error);

                if (success)
                {
                    Notice mess = new Notice("Order deleted successfully!");
                    mess.ShowDialog();
                    this.Parent.Controls.Remove(this); // Xóa UserControl này khỏi giao diện
                }
                else
                {
                    Notice mess = new Notice("Delete failed order!");
                    mess.ShowDialog();
                }
            }
        }

    }
}
