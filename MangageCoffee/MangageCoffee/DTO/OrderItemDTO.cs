using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.DTO
{
    public class OrderItemDTO
    {
        public int ItemID { get; set; }
        public string Name { get; set; }  // Add Name
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice
        {
            get { return Quantity * UnitPrice; }
        }
    }
}
