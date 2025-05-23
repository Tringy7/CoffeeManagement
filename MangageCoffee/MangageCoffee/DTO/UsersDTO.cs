using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; } // bit
        public string Email { get; set; }

        // Thêm các thuộc tính chi tiết từ các bảng Admins, Customers, Staffs
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ImagePath { get; set; } // Đường dẫn ảnh đại diện

        // Thuộc tính riêng cho Staff
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HireDate { get; set; }

        // Thuộc tính riêng cho Customer
        public int? TotalOrders { get; set; }
        public int? TotalFeedbacks { get; set; }
        public decimal? TotalSpent { get; set; }


        public UserDTO() { }

        public UserDTO(string username, string password, string email = "", string role = "Customer", bool status = true)
        {
            Username = username;
            Password = password;
            Email = email;
            Role = role;
            Status = status;
        }
    }


}
