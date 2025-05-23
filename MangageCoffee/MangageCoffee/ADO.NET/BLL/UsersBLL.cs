using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;

namespace MangageCoffee.ADO.NET.BLL
{
    public class UserBLL
    {
        private UserDAL dal = new UserDAL();

        public UserDTO Login(string username, string password)
        {
            var user = dal.CheckLogin(username, password);
            if (user == null)
                return null;

            return dal.GetUserDetails(user);
        }

        public UserDTO GetLoggedInUserInfo()
        {
            return dal.GetLoggedInUser();
        }

        public bool Register(UserDTO user)
        {
            if (dal.IsUsernameTaken(user.Username))
            {
                return false;
            }
            return dal.RegisterUser(user);
        }

        public bool IsUsernameTaken(string username)
        {
            return dal.IsUsernameTaken(username);
        }

        public void SetLoginStatus(string username)
        {
            dal.UpdateLoginStatus(username);
        }

        public void ResetAllUserStatus()
        {
            dal.ResetAllUserStatus();
        }

        // Trong lớp UserBLL
        public List<UserDTO> GetStaffUsers()
        {
            return dal.GetUsersByRole("Staff");
        }

        public List<UserDTO> GetCustomerUsers()
        {
            return dal.GetUsersByRole("Customer");
        }

        //public UserDTO GetLoggedInUserInfo()
        //{
        //    // Phương thức này có thể cần được điều chỉnh để lấy thông tin của người dùng đang đăng nhập thực sự.
        //    // Giả sử có một cơ chế để lấy UserID của người dùng hiện tại sau khi đăng nhập.
        //    // Ví dụ tạm thời: Trả về một người dùng Admin mặc định nếu không có người dùng nào được đăng nhập
        //    // hoặc bạn có thể lưu thông tin người dùng đăng nhập vào một biến tĩnh hoặc Session.
        //    // Hiện tại, code Home.cs gọi phương thức này, nhưng không có logic xác định người dùng đang đăng nhập.
        //    // Để ví dụ này hoạt động, tôi sẽ giả định một UserID có sẵn để test.
        //    // Ví dụ: UserDTO currentUser = new UserDTO { UserID = 1, Role = "Admin" }; 
        //    // return dal.GetUserDetails(currentUser); 
        //    return null; // Cần thay thế bằng logic thực tế
        //}

    }

}
