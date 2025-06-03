using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.DTO;

namespace MangageCoffee.ADO.NET.DAL
{
    public class MenuDAL
    {
        DB_Main db = null;

        public MenuDAL()
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

    }
}
