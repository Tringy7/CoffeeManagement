using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.DTO;

namespace MangageCoffee.ADO.NET.DAL
{
    public class HistoryDAL
    {
        DB_Main db = new DB_Main();
        public DataSet getOrderData()
        {
            string sqlString = "SELECT * FROM Orders WHERE Available = 'True'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public List<Class_Oder> getOrderList()
        {
            List<Class_Oder> orders = new List<Class_Oder>();
            DataSet ds = getOrderData();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Class_Oder order = new Class_Oder
                {
                    OderId = Convert.ToInt32(row["OrderID"]),
                    ItemID = Convert.ToInt32(row["ItemID"]),
                    OderDate = Convert.ToDateTime(row["OrderDate"]),
                    OderTime = (TimeSpan)row["OrderTime"],
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Unitprice = Convert.ToDouble(row["UnitPrice"]),
                    TotalAmount = Convert.ToDouble(row["TotalAmount"]),
                    CustomerID = Convert.ToInt32(row["CustomerID"]),
                    Available = Convert.ToBoolean(row["Available"])

                };

                orders.Add(order);
            }

            return orders;
        }

        public List<Class_Oder> GetListOderByCustomerID(int customerID)
        {
            string query = $"SELECT * FROM Orders WHERE CustomerID = {customerID}";
            DataSet ds = db.ExecuteQueryDataSet(query, CommandType.Text);

            List<Class_Oder> orders = new List<Class_Oder>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Class_Oder order = new Class_Oder
                    {
                        OderId = Convert.ToInt32(row["OrderID"]),
                        ItemID = Convert.ToInt32(row["ItemID"]),
                        OderDate = Convert.ToDateTime(row["OrderDate"]),
                        OderTime = (TimeSpan)row["OrderTime"], // nếu trong SQL là kiểu TIME
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        Unitprice = Convert.ToDouble(row["UnitPrice"]),
                        TotalAmount = Convert.ToDouble(row["TotalAmount"]),
                        CustomerID = Convert.ToInt32(row["CustomerID"]),
                        Available = Convert.ToBoolean(row["Available"])

                    };

                    orders.Add(order);
                }
            }

            return orders;
        }

        public List<Class_Oder> GetListOderByCustomerDateTime(int customerID, DateTime orderDate, TimeSpan orderTime)
        {
            string query = @"
        SELECT [OrderID], [ItemID], [OrderDate], [OrderTime], [Quantity], 
               [UnitPrice], [TotalAmount], [CustomerID], [Available]
        FROM Orders
        WHERE CustomerID = @CustomerID
          AND CAST(OrderDate AS DATE) = @OrderDate
          AND OrderTime = @OrderTime";

            var parameters = new[]
            {
        new SqlParameter("@CustomerID", customerID),
        new SqlParameter("@OrderDate", orderDate.Date),
        new SqlParameter("@OrderTime", orderTime)
    };

            DataSet ds = db.ExecuteQueryDataSet(query, CommandType.Text, parameters);

            var result = new List<Class_Oder>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Class_Oder order = new Class_Oder();

                    order.OderId = Convert.ToInt32(row["OrderID"]);
                    order.ItemID = Convert.ToInt32(row["ItemID"]);
                    order.OderDate = Convert.ToDateTime(row["OrderDate"]);
                    order.OderTime = (TimeSpan)row["OrderTime"];
                    order.Quantity = Convert.ToInt32(row["Quantity"]);
                    order.Unitprice = Convert.ToDouble(row["UnitPrice"]);
                    order.TotalAmount = Convert.ToDouble(row["TotalAmount"]);
                    order.CustomerID = Convert.ToInt32(row["CustomerID"]);
                    order.Available = Convert.ToBoolean(row["Available"]);

                    result.Add(order);
                }
            }

            return result;
        }




        public CustomerDisplayDTO GetCustomerInfoByCustomerID(int CustomerID)
        {
            string sqlString = $"SELECT * FROM Customers WHERE CustomerID = {CustomerID}";
            DataSet ds = db.ExecuteQueryDataSet(sqlString, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return new CustomerDisplayDTO(
                    Convert.ToInt32(row["UserID"]),
                    Convert.ToInt32(row["CustomerID"]),
                    row["FullName"].ToString(),
                    row["Phone"].ToString(),
                    row["Gender"].ToString(),
                    row["DateOfBirth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DateOfBirth"]),
                    row["ImagePath"].ToString(),
                    row["TotalOrders"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["TotalOrders"]),
                    row["TotalFeedbacks"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["TotalFeedbacks"]),
                    row["TotalSpent"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["TotalSpent"])
                );
            }
            return null;
        }
        public Class_Menu getMenuItemsByItemID(int itemID)
        {
            string sqlstring = $"SELECT * FROM MenuItems WHERE ItemID = {itemID}";

            DataSet ds = db.ExecuteQueryDataSet(sqlstring, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                Class_Menu menu = new Class_Menu
                (
                    Convert.ToInt32(row["ItemID"]),
                    row["Name"].ToString(),
                    row["Description"].ToString(),
                    Convert.ToDouble(row["Price"]),
                    row["Category"].ToString(),
                    row["Status"].ToString(),
                    Convert.ToInt32(row["DiscountPercent"]),
                    Convert.ToInt32(row["CreatedBy"]),
                    row["ImagePath"].ToString(),
                    Convert.ToInt32(row["ProductID"]),
                    Convert.ToBoolean(row["Available"])

                );

                return menu;
            }

            return null;
        }



        public List<Class_Oder> GetOrdersByUserID(int userID)
        {
            string sqlString = $"SELECT * FROM Orders WHERE UserID = {userID}";
            DataSet ds = db.ExecuteQueryDataSet(sqlString, CommandType.Text);

            List<Class_Oder> orders = new List<Class_Oder>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Class_Oder order = new Class_Oder
                    {
                        OderId = Convert.ToInt32(row["OrderID"]),
                        ItemID = Convert.ToInt32(row["ItemID"]),
                        OderDate = Convert.ToDateTime(row["OrderDate"]),
                        OderTime = (TimeSpan)row["OrderTime"],
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        Unitprice = Convert.ToDouble(row["UnitPrice"]),
                        Available = Convert.ToBoolean(row["Available"])
                    };

                    orders.Add(order);
                }
            }

            return orders;
        }


        public bool DeleteOrderByOderID(int orderID, ref string error)
        {
            string sqlDeleteOrder = "UPDATE Orders SET Available = 0 WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@OrderID", orderID)
            };

            return db.MyExecuteNonQuery(sqlDeleteOrder, CommandType.Text, ref error, parameters);
        }

    }
}
