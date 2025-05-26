using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.DTO
{
    public class CustomerDisplayDTO
    {
        public int UserID { get; set; }
        public string CustomerID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int? TotalOrders { get; set; }
        public int? TotalFeedbacks { get; set; }
        public decimal? TotalSpent { get; set; }

        public CustomerDisplayDTO() { }
    }
}
