using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms.Suite;
using System.Xml.Linq;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;
using MangageCoffee.UICoffee.ManageDishes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace MangageCoffee.ADO.NET.BLL
{
    public class BL_history
    {
        DB_Main db = null;
        HistoryDAL historyDAL = new HistoryDAL();
        public BL_history()
        {
            db = new DB_Main();

        }
       

        public List<Class_Oder> getOrderList()
        {
            return historyDAL.getOrderList();
        }

        public List<Class_Oder> GetListOderByCustomerID(int customerID)
        {
            return historyDAL.GetListOderByCustomerID(customerID);
        }

        public List<Class_Oder> GetListOderByCustomerDateTime(int customerID, DateTime orderDate, TimeSpan orderTime)
        {
            return historyDAL.GetListOderByCustomerDateTime(customerID, orderDate, orderTime);
        }




        public CustomerDisplayDTO GetCustomerInfoByCustomerID(int CustomerID)
        {
            return historyDAL.GetCustomerInfoByCustomerID(CustomerID);
        }
        public Class_Menu getMenuItemsByItemID(int itemID)
        {
          return historyDAL.getMenuItemsByItemID(itemID);
        }



        public List<Class_Oder> GetOrdersByUserID(int userID)
        {
            return historyDAL.GetOrdersByUserID(userID);
        }

        
        public bool DeleteOrderByOderID(int orderID, ref string error)
        {
            return historyDAL.DeleteOrderByOderID(orderID, ref error);
        }



    }
}
