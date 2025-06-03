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
        
        public static UserDTO CurrentUser { get; private set; }

        private UserDAL dal = new UserDAL();

        public UserDTO Login(string username, string password)
        {
            var user = dal.CheckLogin(username, password);
            if (user == null)
                return null;

            dal.UpdateLoginStatus(username); //  Update login status
            return dal.GetLoggedInUser(); //  Get the logged-in user's details
        }

        public UserDTO GetLoggedInUserInfo()
        {
            UserDTO user = dal.GetLoggedInUser();
            Console.WriteLine($"GetLoggedInUserInfo - KPI: {user?.KPI}"); 
            return user;
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

        public List<StaffDisplayDTO> GetStaffDisplayData()
        {
            return dal.GetStaffDisplayData();
        }

        public List<CustomerDisplayDTO> GetCustomerDisplayData()
        {
            return dal.GetCustomerDisplayData();
        }

        public bool UpdateUser(UserDTO user)
        {
            return dal.UpdateUser(user);
        }

        public void SetUserAvailability(int userId, bool available)
        {
            dal.SetUserAvailability(userId, available);
        }

        public bool AddStaff(UserDTO staff)
        {
            return dal.AddStaff(staff);
        }

        public bool UpdateAdmin(UserDTO admin)
        {
            return dal.UpdateAdmin(admin);
        }

        public bool UpdateCustomer(UserDTO cus)
        {
            return dal.UpdateCustomer(cus);
        }

        public int GetStaffCount()
        {
            return dal.GetStaffCount();
        }

        public int GetCustomerCount()
        {
            return dal.GetCustomerCount();
        }

        public int GetProductCount()
        {
            return dal.GetProductCount();
        }

        public int GetProfitCount()
        {
            return dal.GetProfitCount();
        }
    }

}
