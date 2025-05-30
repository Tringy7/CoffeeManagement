using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MangageCoffee.ADO.NET.BLL
{
    public class BL_Order
    {
        DB_Main db = new DB_Main();

        public int GetOrCreateCustomer(CustomerInfoDTO customerInfo, ref string error)
        {
            DataSet ds = db.GetCustomerByName(customerInfo.FullName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return (int)ds.Tables[0].Rows[0]["CustomerID"];
            }
            else
            {
                return db.AddCustomer(customerInfo.FullName, customerInfo.Phone, ref error);
            }
        }

        DB_Main dal = new DB_Main();

        public int CreateOrder(int customerId, List<OrderItemDTO> items, ref string error)
        {
            double totalAmount = items.Sum(item => item.Quantity * item.UnitPrice);
            int orderId = -1;

            try
            {
                dal.BeginTransaction(); // bắt đầu transaction

                orderId = dal.AddOrder(customerId, totalAmount, ref error);
                if (orderId <= 0)
                {
                    dal.RollbackTransaction();
                    return -1;
                }

                foreach (OrderItemDTO item in items)
                {
                    if (!dal.AddOrderDetails(orderId, item, ref error))
                    {
                        dal.RollbackTransaction();
                        return -1;
                    }

                    // Nếu cần trừ nguyên liệu tồn kho
                    var productInfo = dal.GetProductInfo(item.ItemID, ref error);
                    if (productInfo != null && productInfo.Tables[0].Rows.Count > 0)
                    {
                        int productId = (int)productInfo.Tables[0].Rows[0]["ProductID"];
                        if (!dal.UpdateProductQuantity(productId, item.Quantity, ref error))
                        {
                            dal.RollbackTransaction();
                            return -1;
                        }
                    }
                }

                dal.CommitTransaction();
                return orderId;
            }
            catch (Exception ex)
            {
                dal.RollbackTransaction();
                error = ex.Message;
                return -1;
            }
        }

    }
}
