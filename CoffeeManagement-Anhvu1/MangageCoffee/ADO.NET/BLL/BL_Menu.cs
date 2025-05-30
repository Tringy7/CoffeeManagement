using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;

namespace MangageCoffee.ADO.NET.BLL
{
    internal class BL_Menu
    {
        DB_Main db = null;

        public BL_Menu()
        {
            db = new DB_Main();
        }

        public DataSet getData()
        {
            string sqlString = "SELECT * FROM MenuItems WHERE Status = 'True' AND Available = 'True'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

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
                    CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                    ImagePath = row["ImagePath"].ToString(),
                    Available = Convert.ToBoolean(row["Available"])

                };
                items.Add(item);
            }

            return items;
        }

        //public bool addNewMenuItem(Class_Menu item, ref string error)
        //{
        //    string sqlString = "INSERT INTO MenuItems (Name, Description, Price, Category, Status, DiscountPercent, CreatedBy,ImagePath) " +
        //                       "VALUES (@Name, @Description, @Price, @Category, @Status, @DiscountPercent, @CreatedBy,@ImagePath)";

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //    new SqlParameter("@Name", item.Name),
        //    new SqlParameter("@Description", item.Description),
        //    new SqlParameter("@Price", item.Price),
        //    new SqlParameter("@Category", item.Category),
        //    new SqlParameter("@Status", item.Status),
        //    new SqlParameter("@DiscountPercent", item.Discount),
        //    new SqlParameter("@CreatedBy", item.CreatedBy),
        //    new SqlParameter("@ImagePath", item.ImagePath)

        //    };

        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error, parameters);
        //}

        //public bool updateMenuItem(Class_Menu item, ref string error)
        //{
        //    string sqlString = "UPDATE MenuItems SET Name = @Name, Description = @Description, Price = @Price, " +
        //                       "Category = @Category, Status = @Status, DiscountPercent = @DiscountPercent, CreatedBy = @CreatedBy, " +
        //                       "ImagePath = @ImagePath " +  
        //                       "WHERE ItemID = @ItemID";

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@ItemID", item.Item_id),
        //        new SqlParameter("@Name", item.Name),
        //        new SqlParameter("@Description", item.Description),
        //        new SqlParameter("@Price", item.Price),
        //        new SqlParameter("@Category", item.Category),
        //        new SqlParameter("@Status", item.Status),
        //        new SqlParameter("@DiscountPercent", item.Discount),
        //        new SqlParameter("@CreatedBy", item.CreatedBy),
        //        new SqlParameter("@ImagePath", item.ImagePath) 
        //    };

        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error, parameters);
        //}


        //public bool deleteMenuItem(int itemId, ref string error)
        //{
        //    string sqlString = "DELETE FROM MenuItems WHERE ItemID = @ItemID";

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //    new SqlParameter("@ItemID", itemId)
        //    };

        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error, parameters);
        //}

    public Class_Menu getMenuItemByID(int itemId)
        {
            Class_Menu product = null;
            string error = "";
            DataSet ds = db.GetProductInfo(itemId, ref error); // Use DAL method  
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                product = new Class_Menu
                {
                    Item_id = itemId,
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    OriginalPrice = Convert.ToDouble(row["OriginalPrice"]) // Explicitly cast decimal to double  
                };
            }
            if (product == null)
            {
                product = new Class_Menu
                {
                    Item_id = itemId,
                    ProductID = -1, 
                    OriginalPrice = 0
                };
            }
            return product;
        }
        
    }
}
