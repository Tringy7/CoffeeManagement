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
    public class DB_Main
    {
        public string ConnStr = "Data Source=(local);Initial Catalog=CafeManagementV0;Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        private SqlTransaction transaction = null;

        public DB_Main()
        {
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }

        public void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public SqlConnection GetConnection()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
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
            string sql = "SELECT CustomerID, Phone FROM Customers WHERE FullName = @Name";
            SqlParameter param = new SqlParameter("@Name", customerName);
            return ExecuteQueryDataSet(sql, CommandType.Text, param);
        }

        public int AddCustomer(string customerName, string customerPhoneNumber, ref string error)
        {
            string sql = "INSERT INTO Customers (FullName, Phone) VALUES (@Name, @PhoneNumber); SELECT SCOPE_IDENTITY();";
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

        public DataSet GetProductInfo(int itemId, ref string error)
        {
            string sql = "SELECT p.ProductID, p.OriginalPrice " +
                         "FROM MenuItems mi " +
                         "JOIN Products p ON mi.Name = p.Name " +
                         "WHERE mi.ItemID = @ItemID";
            SqlParameter param = new SqlParameter("@ItemID", itemId);
            return ExecuteQueryDataSet(sql, CommandType.Text, param);
        }
        
        private bool ExecuteNonQuery(string sql, CommandType commandType, ref string error, SqlParameter[] parameters, SqlTransaction transaction = null)
        {
            using (SqlCommand command = new SqlCommand(sql, GetConnection(), transaction))
            {
                command.CommandType = commandType;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public bool UpdateProductQuantity(int productId, int quantity, ref string error)
        {
            try
            {
                // 1. Lấy số lượng hiện tại
                string checkSql = "SELECT Quantity FROM Products WHERE ProductID = @ProductID";
                SqlParameter[] checkParams = new SqlParameter[]
                {
            new SqlParameter("@ProductID", productId)
                };

                DataSet ds = this.ExecuteQueryDataSet(checkSql, CommandType.Text, checkParams);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    error = "Sản phẩm không tồn tại.";
                    return false;
                }

                int currentQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["Quantity"]);

                // 2. Kiểm tra số lượng có đủ hay không
                if (currentQuantity < quantity)
                {
                    error = $"Không đủ số lượng sản phẩm. Hiện có {currentQuantity}, yêu cầu {quantity}.";
                    return false;
                }

                // 3. Trừ số lượng
                string updateSql = "UPDATE Products SET Quantity = Quantity - @Quantity WHERE ProductID = @ProductID";
                SqlParameter[] updateParams = new SqlParameter[]
                {
            new SqlParameter("@ProductID", productId),
            new SqlParameter("@Quantity", quantity)
                };

                return MyExecuteNonQuery(updateSql, CommandType.Text, ref error, updateParams);
            }
            catch (Exception ex)
            {
                error = "Lỗi hệ thống: " + ex.Message;
                return false;
            }
        }


        public bool SaveDailyProfit(DateTime summaryDate, decimal profit, int orderCount, ref string error, SqlTransaction transaction)
        {
            string sql = "INSERT INTO DailyProfitSummary (SummaryDate, Profit, OrderCount) " +
                         "VALUES (@SummaryDate, @Profit, @OrderCount)";
            SqlParameter[] parameters = {
            new SqlParameter("@SummaryDate", SqlDbType.Date) { Value = summaryDate },
            new SqlParameter("@Profit", SqlDbType.Decimal) { Value = profit },
            new SqlParameter("@OrderCount", SqlDbType.Int) { Value = orderCount }
        };
            return ExecuteNonQuery(sql, CommandType.Text, ref error, parameters, transaction);
        }

        public SqlTransaction BeginTransaction()
        {
            OpenConnection(); 
            transaction = conn.BeginTransaction();
            comm.Transaction = transaction; // Assign transaction to command
            return transaction;
        }

        public void CommitTransaction()
        {
            transaction.Commit();
            CloseConnection();
        }

        public void RollbackTransaction()
        {
            transaction.Rollback();
            CloseConnection();
        }

        public bool InsertOrder(int itemID, DateTime orderDate, TimeSpan orderTime, int quantity, decimal unitPrice, decimal totalAmount, int customerID, bool available, SqlTransaction transaction, ref string error)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders (ItemID, OrderDate, OrderTime, Quantity, UnitPrice, TotalAmount, CustomerID, Available) " +
                                                       "VALUES (@ItemID, @OrderDate, @OrderTime, @Quantity, @UnitPrice, @TotalAmount, @CustomerID, @Available)", conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@ItemID", itemID);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate.Date);
                    cmd.Parameters.AddWithValue("@OrderTime", orderTime);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@Available", available);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
