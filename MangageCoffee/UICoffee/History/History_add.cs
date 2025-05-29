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
    public partial class History_add : UserControl
    {
        BL_history bl_history = null;
        public History_add()
        {

            InitializeComponent();
            bl_history = new BL_history();
            loaddata();
        }

        private void loaddata()
        {
            flowLayoutPanelHistory.Controls.Clear();

            List<Class_Oder> listHistory = bl_history.getOrderList();

            // Tạo HashSet để lưu CustomerID đã xử lý
            HashSet<int> processedCustomerIDs = new HashSet<int>();

            foreach (Class_Oder ItemHistory_Oder in listHistory)
            {
                if (processedCustomerIDs.Contains(ItemHistory_Oder.CustomerID))
                    continue; // Nếu đã xử lý CustomerID này thì bỏ qua

                processedCustomerIDs.Add(ItemHistory_Oder.CustomerID); // Đánh dấu là đã xử lý

                History_order history_Order = new History_order();
                history_Order.setdata(ItemHistory_Oder);
                flowLayoutPanelHistory.Controls.Add(history_Order);
            }

        }
        private void text_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = text_search.Text.Trim().ToLower();

            flowLayoutPanelHistory.Controls.Clear();
            List<Class_Oder> listHistory = bl_history.getOrderList();
            HashSet<int> processedCustomerIDs = new HashSet<int>();

            foreach (Class_Oder item in listHistory)
            {
                if (processedCustomerIDs.Contains(item.CustomerID))
                    continue;

                CustomerDisplayDTO customer = bl_history.GetCustomerInfoByCustomerID(item.CustomerID);
                if (customer != null && customer.FullName.ToLower().Contains(keyword))
                {
                    processedCustomerIDs.Add(item.CustomerID);

                    History_order history_Order = new History_order();
                    history_Order.setdata(item);
            // đăng ký sự kiện xoá
                    
                    flowLayoutPanelHistory.Controls.Add(history_Order);
                }
            }
        }
























        private void guna2Button1_Click(object sender, EventArgs e)
        {
            history_historyform1.BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            history_historyform1.SendToBack();
        }

        private void flowLayoutPanelHistory_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
