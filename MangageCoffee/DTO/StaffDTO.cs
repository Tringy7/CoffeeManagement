using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.DTO
{
    public class StaffDisplayDTO
    {
        public int UserID { get; set; }
        public string StaffID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HireDate { get; set; }

        public StaffDisplayDTO() { }
    }
   
}
