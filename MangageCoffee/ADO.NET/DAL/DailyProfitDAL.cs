using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.ADO.NET.DAL
{
    public class DailyProfitDAL
    {
        private string connectionString;

        public DailyProfitDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetDailyProfitSummaryData()
        {
            string query = "SELECT TOP (1000) [SummaryDate], [Profit], [OrderCount] FROM [CafeManagementV0].[dbo].[DailyProfitSummary]";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error appropriately
                Console.WriteLine("DAL Error: " + ex.Message);
                throw; // Re-throw the exception to be handled in the BLL
            }

            return dataTable;
        }

    }
}
