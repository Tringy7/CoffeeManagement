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
using System.IO;
using MangageCoffee.UICoffee.User;
using MangageCoffee.ADO.NET.DAL;

namespace MangageCoffee.UICoffee
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            LoadUserInfo();
            LoadStaffAndCustomerCounts();
            chart.Visible = true; // Ensure the chart is visible
            chart1.Visible = false; // Hide the second chart if not needed
            lblChart.Text = "Biểu đồ lợi nhuận theo ngày";
        }

        private UserBLL userBLL = new UserBLL();
        private DailyProfitBLL profitBLL = new DailyProfitBLL(new DB_Main().ConnStr);

        private void LoadUserInfo()
        {
            UserDTO user = userBLL.GetLoggedInUserInfo(); 

            if (user == null)
            {
                MessageBox.Show("Không có người dùng đang đăng nhập.");
                return;
            }

            lblHoTen.Text = user.FullName ?? "";
            lblRole.Text = user.Role ?? "";
            lblGender.Text = user.Gender ?? "";
            lblDate.Text = user.DateOfBirth?.ToString("dd/MM/yyyy") ?? "";
            lblSDT.Text = user.Phone ?? "";
            Console.WriteLine($"Home.LoadUserInfo - KPI: {user?.KPI}"); // Add this
            cpbKPI.Value = user.KPI ?? 0;
            lblKPI.Text = (user.KPI ?? 0).ToString() + "%";

            string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string fullImagePath = Path.Combine(imageFolderPath, user.ImagePath ?? "default.png");

            if (File.Exists(fullImagePath))
            {
                try
                {
                    using (Image img = Image.FromFile(fullImagePath))
                    {
                        ptbAvatar.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}\nĐường dẫn: {fullImagePath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ptbAvatar.Image = null;
                }
            }
            else
            {
                string defaultImagePath = Path.Combine(imageFolderPath, "default.png");
                if (File.Exists(defaultImagePath))
                {
                    ptbAvatar.Image = Image.FromFile(defaultImagePath);
                }
                else
                {
                    ptbAvatar.Image = null;
                    MessageBox.Show($"Không tìm thấy ảnh: {fullImagePath} và không có ảnh mặc định tại {defaultImagePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserDTO loggedInAdmin = userBLL.GetLoggedInUserInfo(); // Get the current Admin's data
            if (loggedInAdmin != null && loggedInAdmin.Role == "Admin")
            {
                EditAdminForm editForm = new EditAdminForm(loggedInAdmin);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUserInfo(); // Refresh Home.cs after editing
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa thông tin này.");
            }
        }

        private void LoadStaffAndCustomerCounts()
        {
            lblTongNV.Text = userBLL.GetStaffCount().ToString();
            lblTongKH.Text = userBLL.GetCustomerCount().ToString();
            lblTongSP.Text = userBLL.GetProductCount().ToString();
        }

        private void chart_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = profitBLL.GetProfitDataForChart();
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    chart.DataSets.Clear();
                    chart.CustomXAxis = new string[0];
                    chart.Invalidate();
                    return;
                }

                // GỘP DỮ LIỆU THEO NGÀY VÀ TÍNH TỔNG PROFIT
                var groupedData = dataTable.AsEnumerable()
                    .Where(row => row["SummaryDate"] != DBNull.Value && row["Profit"] != DBNull.Value)
                    .GroupBy(row => Convert.ToDateTime(row["SummaryDate"]).ToString("dd/MM"))
                    .Select(g => new
                    {
                        Date = g.Key,
                        TotalProfit = g.Sum(r => Convert.ToSingle(r["Profit"]))
                    })
                    .OrderBy(x => DateTime.ParseExact(x.Date, "dd/MM", null)) // sắp xếp theo ngày
                    .ToList();

                // GÁN DỮ LIỆU LÊN BIỂU ĐỒ LỢI NHUẬN
                chart.DataSets.Clear();
                chart.CustomXAxis = groupedData.Select(x => x.Date).ToArray();

                // Determine MaxValue for Profit Chart
                float maxProfit = groupedData.Max(x => x.TotalProfit);
                chart.MaxValue = maxProfit + maxProfit * 0.2f; // Add some padding

                var profitDataSet = new FrameworkTest.Charts.SATALineChart.DataSet
                {
                    Label = "Lợi nhuận",
                    LineColor = Color.FromArgb(8, 79, 165),
                    PointColor = Color.FromArgb(8, 79, 165),
                    Points = groupedData.Select(x => x.TotalProfit).ToArray()
                };
                chart.DataSets.Add(profitDataSet);

                chart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ lợi nhuận: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChartProfit_Click(object sender, EventArgs e)
        {
            chart.Visible = true; // Hiển thị biểu đồ lợi nhuận
            chart1.Visible = false; // Ẩn biểu đồ khác nếu có
            lblChart.Text = "Biểu đồ lợi nhuận theo ngày"; // Cập nhật tiêu đề biểu đồ
        }

        private void btnChartOrder_Click(object sender, EventArgs e)
        {
            chart.Visible = false; // Ẩn biểu đồ lợi nhuận
            chart1.Visible = true; // Hiển thị biểu đồ khác nếu có
            lblChart.Text = "Biểu đồ số lượng đơn theo ngày"; // Cập nhật tiêu đề biểu đồ
        }

        private void chart1_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = profitBLL.GetProfitDataForChart();
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    chart1.DataSets.Clear();
                    chart1.CustomXAxis = new string[0];
                    chart1.Invalidate();
                    return;
                }

                // GỘP DỮ LIỆU THEO NGÀY VÀ TÍNH TỔNG SỐ ĐƠN
                var groupedData = dataTable.AsEnumerable()
                    .Where(row => row["SummaryDate"] != DBNull.Value && row["OrderCount"] != DBNull.Value)
                    .GroupBy(row => Convert.ToDateTime(row["SummaryDate"]).ToString("dd/MM"))
                    .Select(g => new
                    {
                        Date = g.Key,
                        TotalOrders = g.Sum(r => Convert.ToInt32(r["OrderCount"]))
                    })
                    .OrderBy(x => DateTime.ParseExact(x.Date, "dd/MM", null)) // sắp xếp theo ngày
                    .ToList();

                // GÁN DỮ LIỆU LÊN BIỂU ĐỒ SỐ LƯỢNG ĐƠN
                chart1.DataSets.Clear();
                chart1.CustomXAxis = groupedData.Select(x => x.Date).ToArray();

                // Determine MaxValue for Order Count Chart
                int maxOrders = groupedData.Max(x => x.TotalOrders);
                chart1.MaxValue = maxOrders + maxOrders * 0.2f; // Add some padding

                var orderCountDataSet = new FrameworkTest.Charts.SATALineChart.DataSet
                {
                    Label = "Số lượng đơn",
                    LineColor = Color.FromArgb(255, 128, 0), // Chọn màu
                    PointColor = Color.FromArgb(255, 128, 0),
                    Points = groupedData.Select(x => (float)x.TotalOrders).ToArray()
                };
                chart1.DataSets.Add(orderCountDataSet);

                chart1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ số đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
