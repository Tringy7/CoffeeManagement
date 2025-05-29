using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.DTO
{
    public class Class_Oder
    {
        private int oderId;
        private int itemID;
        private DateTime oderDate;
        private TimeSpan oderTime;
        private int quantity;
        private double unitprice;
        private double totalAmount;
        private int customerID;
        private bool available;

        public Class_Oder()
        {

        }

        public Class_Oder(int oderId, int itemID, DateTime oderDate, TimeSpan oderTime, int quantity, double unitprice, double totalAmount, int customerID, bool available)
        {
            this.oderId = oderId;
            this.itemID = itemID;
            this.oderDate = oderDate;
            this.oderTime = oderTime;
            this.quantity = quantity;
            this.unitprice = unitprice;
            this.totalAmount = totalAmount;
            this.customerID = customerID;
            this.available = available;
        }

        public int OderId { get => oderId; set => oderId = value; }
        public int ItemID { get => itemID; set => itemID = value; }
        public DateTime OderDate { get => oderDate; set => oderDate = value; }
        public TimeSpan OderTime { get => oderTime; set => oderTime = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Unitprice { get => unitprice; set => unitprice = value; }
        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public bool Available { get => available; set => available = value; }
    }
}
