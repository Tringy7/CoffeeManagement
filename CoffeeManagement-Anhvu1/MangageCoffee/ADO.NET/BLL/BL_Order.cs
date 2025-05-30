using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;
using System.Data;

namespace MangageCoffee.ADO.NET.BLL
{
    public class BL_Order
    {
        DB_Main db = new DB_Main();

        // Get or Create Customer
        public int GetOrCreateCustomer(CustomerInfoDTO customerInfo, ref string error)
        {
            DataSet ds = db.GetCustomerByName(customerInfo.Name);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // Customer exists
                return (int)ds.Tables[0].Rows[0]["CustomerID"];
            }
            else
            {
                // Create customer
                return db.AddCustomer(customerInfo.Name, customerInfo.PhoneNumber, ref error);
            }
        }

        // Create Order and Order Details
        public int CreateOrder(int customerId, List<OrderItemDTO> orderItems, ref string error)
        {
            double totalAmount = orderItems.Sum(item => item.UnitPrice * item.Quantity);
            int orderId = db.AddOrder(customerId, totalAmount, ref error);

            if (orderId > 0)
            {
                foreach (OrderItemDTO item in orderItems)
                {
                    if (!db.AddOrderDetails(orderId, item, ref error))
                    {
                        // Handle error (e.g., log, throw exception, etc.)
                        return -1;
                    }
                }
            }
            return orderId;
        }
    }
}
