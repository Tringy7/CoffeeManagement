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
    internal class DB_Main
    {
        string ConnStr = "Data Source=(local);Initial Catalog=CafeManagementV0;Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;

        public DB_Main()
        {
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();

                comm.Connection = conn;
                comm.CommandText = strSQL;
                comm.CommandType = ct;
                comm.Parameters.Clear();
                if (parameters != null)
                    comm.Parameters.AddRange(parameters);

                da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện truy vấn dữ liệu: " + ex.Message, ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return ds;
        }


        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] parameters)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Connection = conn;
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            comm.Parameters.Clear();
            if (parameters != null)
                comm.Parameters.AddRange(parameters);

            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }

        public DataSet GetCustomerByName(string customerName)
        {
            string sql = "SELECT CustomerID, PhoneNumber FROM Customers WHERE Name = @Name";
            SqlParameter param = new SqlParameter("@Name", customerName);
            return ExecuteQueryDataSet(sql, CommandType.Text, param);
        }

        // Add new Customer (returns the new CustomerID)
        public int AddCustomer(string customerName, string customerPhoneNumber, ref string error)
        {
            string sql = "INSERT INTO Customers (Name, PhoneNumber) VALUES (@Name, @PhoneNumber); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = {
        new SqlParameter("@Name", customerName),
        new SqlParameter("@PhoneNumber", customerPhoneNumber)
    };
            DataSet ds = ExecuteQueryDataSet(sql, CommandType.Text, parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            else
            {
                error = "Could not create customer.";
                return -1;
            }
        }

        // Add new Order (returns the new OrderID)
        public int AddOrder(int customerId, double totalAmount, ref string error)
        {
            string sql = "INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES (@CustomerID, GETDATE(), @TotalAmount); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = {
        new SqlParameter("@CustomerID", customerId),
        new SqlParameter("@TotalAmount", totalAmount)
    };
            DataSet ds = ExecuteQueryDataSet(sql, CommandType.Text, parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            else
            {
                error = "Could not create order.";
                return -1;
            }
        }

        // Add Order Details
        public bool AddOrderDetails(int orderId, OrderItemDTO item, ref string error)
        {
            string sql = "INSERT INTO OrderDetails (OrderID, ItemID, Quantity, UnitPrice) VALUES (@OrderID, @ItemID, @Quantity, @UnitPrice)";
            SqlParameter[] parameters = {
        new SqlParameter("@OrderID", orderId),
        new SqlParameter("@ItemID", item.ItemID),
        new SqlParameter("@Quantity", item.Quantity),
        new SqlParameter("@UnitPrice", item.UnitPrice)
    };
            return MyExecuteNonQuery(sql, CommandType.Text, ref error, parameters);
        }
    }
}
