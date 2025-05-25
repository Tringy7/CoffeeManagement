using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.DAL;
using MangageCoffee.DTO;

namespace MangageCoffee.BL
{
    internal class BL_Menu
    {
        DB_Main db = null;

        public BL_Menu()
        {
            db = new DB_Main();
        }

        // Lấy toàn bộ dữ liệu menu item
        public DataSet getData()
        {
            string sqlString = "SELECT * FROM MenuItems WHERE Status = 'True'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        // Chuyển dữ liệu thành danh sách đối tượng Class_menuitem
        public List<Class_Menu> getMenuItemList()
        {
            List<Class_Menu> items = new List<Class_Menu>();
            DataSet ds = getData();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Class_Menu item = new Class_Menu
                {
                    Item_id = Convert.ToInt32(row["ItemID"]),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToDouble(row["Price"]),
                    Category = row["Category"].ToString(),
                    Status = row["Status"].ToString(),
                    Discount = Convert.ToInt32(row["DiscountPercent"]),
                    CreatedBy = Convert.ToInt32(row["CreatedBy"])
                };
                items.Add(item);
            }

            return items;
        }

        // Thêm mới menu item
        public bool addNewMenuItem(Class_Menu item, ref string error)
        {
            string sqlString = "INSERT INTO MenuItems (Name, Description, Price, Category, Status, DiscountPercent, CreatedBy) " +
                               "VALUES (@Name, @Description, @Price, @Category, @Status, @DiscountPercent, @CreatedBy)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Name", item.Name),
            new SqlParameter("@Description", item.Description),
            new SqlParameter("@Price", item.Price),
            new SqlParameter("@Category", item.Category),
            new SqlParameter("@Status", item.Status),
            new SqlParameter("@DiscountPercent", item.Discount),
            new SqlParameter("@CreatedBy", item.CreatedBy)
            };

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error, parameters);
        }

        // Cập nhật menu item
        public bool updateMenuItem(Class_Menu item, ref string error)
        {
            string sqlString = "UPDATE MenuItems SET Name = @Name, Description = @Description, Price = @Price, " +
                               "Category = @Category, Status = @Status, DiscountPercent = @DiscountPercent, CreatedBy = @CreatedBy " +
                               "WHERE ItemID = @ItemID";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ItemID", item.Item_id),
            new SqlParameter("@Name", item.Name),
            new SqlParameter("@Description", item.Description),
            new SqlParameter("@Price", item.Price),
            new SqlParameter("@Category", item.Category),
            new SqlParameter("@Status", item.Status),
            new SqlParameter("@DiscountPercent", item.Discount),
            new SqlParameter("@CreatedBy", item.CreatedBy)
            };

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error, parameters);
        }

        // Xóa menu item
        public bool deleteMenuItem(int itemId, ref string error)
        {
            string sqlString = "DELETE FROM MenuItems WHERE ItemID = @ItemID";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ItemID", itemId)
            };

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error, parameters);
        }
    }
}
