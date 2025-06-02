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

            // Dictionary để nhóm đơn hàng theo (CustomerID, OrderTime)
            var groupedOrders = listHistory
                .GroupBy(order => $"{order.CustomerID}_{order.OderTime:hh\\:mm\\:ss}")
                .ToDictionary(g => g.Key, g => g.ToList());

            HashSet<string> processedKeys = new HashSet<string>();

            foreach (var kvp in groupedOrders)
            {
                string key = kvp.Key;

                if (processedKeys.Contains(key))
                    continue;

                processedKeys.Add(key);

                List<Class_Oder> sameTimeOrders = kvp.Value;

                History_order history_Order = new History_order();
                history_Order.setdata(sameTimeOrders); // gửi cả danh sách sản phẩm theo thời điểm

                flowLayoutPanelHistory.Controls.Add(history_Order);
            }
        }


        private void text_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = text_search.Text.Trim().ToLower();
            flowLayoutPanelHistory.Controls.Clear();

            List<Class_Oder> listHistory = bl_history.getOrderList();
            HashSet<string> processedKeys = new HashSet<string>(); // CustomerID + Time

            var groupedOrders = listHistory
                .GroupBy(o => new { o.CustomerID, o.OderTime }) // nhóm theo ID và thời điểm
                .ToList();

            foreach (var group in groupedOrders)
            {
                string key = $"{group.Key.CustomerID}_{group.Key.OderTime:hh\\:mm\\:ss}";
                if (processedKeys.Contains(key))
                    continue;

                CustomerDisplayDTO customer = bl_history.GetCustomerInfoByCustomerID(group.Key.CustomerID);

                if (customer != null && customer.FullName.ToLower().Contains(keyword))
                {
                    processedKeys.Add(key);

                    History_order history_Order = new History_order();
                    history_Order.setdata(group.ToList()); // truyền list đơn hàng mua cùng lúc
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
