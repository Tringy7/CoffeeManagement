using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.ADO.NET.DAL;

namespace MangageCoffee.ADO.NET.BLL
{
    public class DailyProfitBLL
    {
        private DailyProfitDAL profitSummaryDAL;

        public DailyProfitBLL(string connectionString)
        {
            profitSummaryDAL = new DailyProfitDAL(connectionString);
        }

        public DataTable GetProfitDataForChart()
        {
            try
            {
                DataTable dataTable = profitSummaryDAL.GetDailyProfitSummaryData();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("BLL Error: " + ex.Message);
                throw;
            }
        }
    }
}
