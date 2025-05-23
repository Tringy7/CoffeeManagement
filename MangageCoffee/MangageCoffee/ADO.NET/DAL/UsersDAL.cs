using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.DTO;

namespace MangageCoffee.ADO.NET.DAL
{
    public class UserDAL
    {
        private readonly string connectionString = "Data Source=(local);Initial Catalog=CafeManagementV7;Integrated Security=True";

        public UserDTO CheckLogin(string username, string password)
        {
            // Code này giữ nguyên
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password AND Status = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserDTO
                        {
                            UserID = (int)reader["UserID"],
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString(),
                            Status = (bool)reader["Status"],
                            Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        // SỬA ĐỔI PHƯƠNG THỨC GETUSERDETAILS NÀY
        public UserDTO GetUserDetails(UserDTO user)
        {
            if (user == null) return null; // Xử lý trường hợp user rỗng

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;
                SqlCommand cmd;

                if (user.Role == "Admin")
                {
                    query = "SELECT FullName, Phone, Gender, DateOfBirth, ImagePath FROM Admins WHERE UserID = @UserID";
                }
                else if (user.Role == "Customer")
                {
                    // Lấy thêm các trường TotalOrders, TotalFeedbacks, TotalSpent và ImagePath từ bảng Customers
                    query = "SELECT FullName, Phone, Gender, DateOfBirth, ImagePath, TotalOrders, TotalFeedbacks, TotalSpent FROM Customers WHERE UserID = @UserID";
                }
                else if (user.Role == "Staff") // THÊM NHÁNH NÀY CHO STAFF
                {
                    // Lấy thêm các trường Position, Salary, HireDate và ImagePath từ bảng Staffs
                    query = "SELECT FullName, Phone, Gender, DateOfBirth, ImagePath, Position, Salary, HireDate FROM Staffs WHERE UserID = @UserID";
                }
                else
                {
                    // Nếu vai trò không được hỗ trợ, trả về user hiện có mà không có chi tiết bổ sung
                    return user;
                }

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Cập nhật trực tiếp đối tượng 'user' đã được truyền vào
                        user.FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString();
                        user.Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString();
                        user.Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString();
                        user.DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateOfBirth"]);
                        user.ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString(); // Lấy ImagePath từ DB

                        // Gán các thuộc tính đặc trưng theo vai trò
                        if (user.Role == "Customer")
                        {
                            user.TotalOrders = reader["TotalOrders"] == DBNull.Value ? (int?)null : (int)reader["TotalOrders"];
                            user.TotalFeedbacks = reader["TotalFeedbacks"] == DBNull.Value ? (int?)null : (int)reader["TotalFeedbacks"];
                            user.TotalSpent = reader["TotalSpent"] == DBNull.Value ? (decimal?)null : (decimal)reader["TotalSpent"];
                        }
                        else if (user.Role == "Staff")
                        {
                            user.Position = reader["Position"] == DBNull.Value ? null : reader["Position"].ToString();
                            user.Salary = reader["Salary"] == DBNull.Value ? null : (decimal?)reader["Salary"];
                            user.HireDate = reader["HireDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["HireDate"]);
                        }
                    }
                }
            }
            return user; // Trả về đối tượng user đã được cập nhật
        }

        public UserDTO GetLoggedInUser()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string queryUser = "SELECT TOP 1 * FROM Users WHERE Status = 1";
                SqlCommand cmdUser = new SqlCommand(queryUser, conn);

                using (SqlDataReader readerUser = cmdUser.ExecuteReader())
                {
                    if (!readerUser.Read())
                        return null; // Không có user nào đăng nhập

                    var user = new UserDTO()
                    {
                        UserID = (int)readerUser["UserID"],
                        Username = readerUser["Username"].ToString(),
                        Role = readerUser["Role"].ToString(),
                        Status = (bool)readerUser["Status"],
                        Email = readerUser["Email"] == DBNull.Value ? null : readerUser["Email"].ToString()
                    };
                    readerUser.Close(); // Đóng readerUser trước khi mở readerDetail

                    // Sau khi có user cơ bản, gọi lại GetUserDetails để lấy đầy đủ thông tin chi tiết
                    return GetUserDetails(user);
                }
            }
        }

        // Các phương thức RegisterUser, IsUsernameTaken, UpdateLoginStatus, ResetAllUserStatus,
        // GetUsersByRole, GetAllUsers giữ nguyên như bạn đã cung cấp, vì chúng gọi GetUserDetails.
        // GetUsersByRole của bạn đã gọi GetUserDetails trong vòng lặp foreach, điều này là đúng.
        public bool RegisterUser(UserDTO user) { /* ... giữ nguyên ... */ return true; }
        public bool IsUsernameTaken(string username) { /* ... giữ nguyên ... */ return true; }
        public void UpdateLoginStatus(string username) { /* ... giữ nguyên ... */ }
        public void ResetAllUserStatus() { /* ... giữ nguyên ... */ }
        public List<UserDTO> GetUsersByRole(string role)
        {
            List<UserDTO> users = new List<UserDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, Username, Role, Status, Email FROM Users WHERE Role = @Role AND Status = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Role", role);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserDTO user = new UserDTO
                        {
                            UserID = (int)reader["UserID"],
                            Username = reader["Username"].ToString(),
                            Role = reader["Role"].ToString(),
                            Status = (bool)reader["Status"],
                            Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString()
                        };
                        users.Add(user);
                    }
                }
            }

            foreach (var user in users)
            {
                GetUserDetails(user); // Phương thức này sẽ được cập nhật để lấy chi tiết Staff và Customer
            }

            return users;
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> allUsers = new List<UserDTO>();
            allUsers.AddRange(GetUsersByRole("Admin"));
            allUsers.AddRange(GetUsersByRole("Staff"));
            allUsers.AddRange(GetUsersByRole("Customer"));
            return allUsers;
        }
    }
}
