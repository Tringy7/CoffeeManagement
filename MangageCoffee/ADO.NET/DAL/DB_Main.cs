using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.ADO.NET.DAL
{
    internal class DB_Main
    {
        string ConnStr = "Data Source=ANHVU;Initial Catalog=CafeManagementV2;User ID=sa;Password=123;";
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
    }
}
