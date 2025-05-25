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

        public UserDTO GetUserDetails(UserDTO user)
        {
            if (user == null) return null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;
                SqlCommand cmd;

                if (user.Role == "Admin")
                {
                    query = "SELECT FullName, Phone, Gender, DateOfBirth, ImagePath, KPI FROM Admins WHERE UserID = @UserID"; // Get KPI
                }
                else if (user.Role == "Customer")
                {
                    query = "SELECT FullName, Phone, Gender, DateOfBirth, ImagePath, TotalOrders, TotalFeedbacks, TotalSpent FROM Customers WHERE UserID = @UserID";
                }
                else if (user.Role == "Staff")
                {
                    query = "SELECT FullName, Phone, Gender, DateOfBirth, ImagePath, Position, Salary, HireDate FROM Staffs WHERE UserID = @UserID";
                }
                else
                {
                    return user;
                }

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString();
                        user.Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString();
                        user.Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString();
                        user.DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateOfBirth"]);
                        user.ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString();

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
                        else if (user.Role == "Admin")
                        {
                            user.KPI = reader["KPI"] == DBNull.Value ? (int?)null : (int)reader["KPI"]; // Get KPI
                        }
                    }
                }
                return user;
            }
        }

        public void UpdateLoginStatus(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); //  Begin transaction
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    //  Reset all statuses
                    cmd.CommandText = "UPDATE Users SET Status = 0";
                    cmd.ExecuteNonQuery();

                    //  Set status for the current user
                    cmd.CommandText = "UPDATE Users SET Status = 1 WHERE Username = @Username";
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();

                    transaction.Commit(); //  Commit the transaction
                }
                catch (Exception)
                {
                    transaction.Rollback(); //  Rollback on error
                    throw; //  Re-throw the exception
                }
            }
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
                        return null;

                    var user = new UserDTO()
                    {
                        UserID = (int)readerUser["UserID"],
                        Username = readerUser["Username"].ToString(),
                        Role = readerUser["Role"].ToString(),
                        Status = (bool)readerUser["Status"],
                        Email = readerUser["Email"] == DBNull.Value ? null : readerUser["Email"].ToString()
                    };
                    readerUser.Close();

                    return GetUserDetails(user);
                }
            }
        }

        public UserDTO GetUserDetails(int userID) //  Modified to take userID
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;
                SqlCommand cmd;

                //  No need for user.Role checks here, as we get the role from the Users table
                query = @"SELECT u.UserID, u.Username, u.Role, u.Status, u.Email,
                                 a.FullName, a.Phone, a.Gender, a.DateOfBirth, a.ImagePath,
                                 c.TotalOrders, c.TotalFeedbacks, c.TotalSpent,
                                 s.Position, s.Salary, s.HireDate
                          FROM Users u
                          LEFT JOIN Admins a ON u.UserID = a.UserID
                          LEFT JOIN Customers c ON u.UserID = c.UserID
                          LEFT JOIN Staffs s ON u.UserID = s.UserID
                          WHERE u.UserID = @UserID";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var user = new UserDTO
                        {
                            UserID = (int)reader["UserID"],
                            Username = reader["Username"].ToString(),
                            Role = reader["Role"].ToString(),
                            Status = (bool)reader["Status"],
                            Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                            FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString(),
                            Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                            Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString(),
                            DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateOfBirth"]),
                            ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString(),
                            TotalOrders = reader["TotalOrders"] == DBNull.Value ? (int?)null : (int)reader["TotalOrders"],
                            TotalFeedbacks = reader["TotalFeedbacks"] == DBNull.Value ? (int?)null : (int)reader["TotalFeedbacks"],
                            TotalSpent = reader["TotalSpent"] == DBNull.Value ? (decimal?)null : (decimal)reader["TotalSpent"],
                            Position = reader["Position"] == DBNull.Value ? null : reader["Position"].ToString(),
                            Salary = reader["Salary"] == DBNull.Value ? null : (decimal?)reader["Salary"],
                            HireDate = reader["HireDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["HireDate"])
                        };
                        return user;
                    }
                    return null;
                }
            }
        }

        public bool RegisterUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Users (Username, Password, Role, Status, Email) VALUES (@Username, @Password, @Role, @Status, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Status", true); // Mặc định trạng thái là hoạt động khi đăng ký
                cmd.Parameters.AddWithValue("@Email", user.Email == null ? DBNull.Value : (object)user.Email);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public bool IsUsernameTaken(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public void ResetAllUserStatus()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET Status = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public List<UserDTO> GetUsersByRole(string role)
        {
            List<UserDTO> users = new List<UserDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, Username, Role, Status, Email FROM Users WHERE Role = @Role AND Status = 1 AND Available = 1"; //  Only get available users
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
                            Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                            Available = (bool)reader["Available"] //  Get Available status
                        };
                        users.Add(user);
                    }
                }
            }

            foreach (var user in users)
            {
                GetUserDetails(user);
            }

            return users;
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> allUsers = new List<UserDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, Username, Role, Status, Email, Available FROM Users WHERE Available = 1"; //  Only get available users
                SqlCommand cmd = new SqlCommand(query, conn);

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
                            Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                            Available = (bool)reader["Available"]
                        };
                        allUsers.Add(user);
                    }
                }
            }

            foreach (var user in allUsers)
            {
                GetUserDetails(user);
            }

            return allUsers;
        }
        public void SetUserAvailability(int userId, bool available)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET Available = @Available WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Available", available);
                cmd.ExecuteNonQuery();
            }
        }

        public List<StaffDisplayDTO> GetStaffDisplayData()
        {
            List<StaffDisplayDTO> staffList = new List<StaffDisplayDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT u.UserID, u.Username, u.Role, s.StaffID, s.FullName, s.Phone, s.Gender, s.DateOfBirth, s.ImagePath, s.Position, s.Salary, s.HireDate
                                  FROM Users u
                                  INNER JOIN Staffs s ON u.UserID = s.UserID
                                  WHERE u.Role = 'Staff' AND u.Available = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        staffList.Add(new StaffDisplayDTO
                        {
                            UserID = (int)reader["UserID"],
                            StaffID = reader["StaffID"] == DBNull.Value ? null : reader["StaffID"].ToString(),
                            Username = reader["Username"].ToString(),
                            FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString(),
                            Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                            Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString(),
                            DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateOfBirth"]),
                            ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString(),
                            Position = reader["Position"] == DBNull.Value ? null : reader["Position"].ToString(),
                            Salary = reader["Salary"] == DBNull.Value ? null : (decimal?)reader["Salary"], // Fixed type conversion
                            HireDate = reader["HireDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["HireDate"])
                        });
                    }
                }
            }
            return staffList;
        }

        public List<CustomerDisplayDTO> GetCustomerDisplayData()
        {
            List<CustomerDisplayDTO> customerList = new List<CustomerDisplayDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT u.UserID, u.Username, u.Role, c.CustomerID,c.FullName, c.Phone, c.Gender, c.DateOfBirth, c.ImagePath, c.TotalOrders, c.TotalFeedbacks, c.TotalSpent
                                  FROM Users u
                                  INNER JOIN Customers c ON u.UserID = c.UserID
                                  WHERE u.Role = 'Customer'";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerList.Add(new CustomerDisplayDTO
                        {
                            UserID = (int)reader["UserID"],
                            CustomerID = reader["CustomerID"] == DBNull.Value ? null : reader["CustomerID"].ToString(),
                            Username = reader["Username"].ToString(),
                            FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString(),
                            Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                            Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString(),
                            DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateOfBirth"]),
                            ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString(),
                            TotalOrders = reader["TotalOrders"] == DBNull.Value ? (int?)null : (int)reader["TotalOrders"],
                            TotalFeedbacks = reader["TotalFeedbacks"] == DBNull.Value ? (int?)null : (int)reader["TotalFeedbacks"],
                            TotalSpent = reader["TotalSpent"] == DBNull.Value ? null : (decimal?)reader["TotalSpent"]
                        });
                    }
                }
            }
            return customerList;
        }

        public bool UpdateUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Staffs 
                               SET FullName = @FullName, 
                                   Phone = @Phone, 
                                   Gender = @Gender, 
                                   DateOfBirth = @DateOfBirth, 
                                   Position = @Position, 
                                    ImagePath = @ImagePath,
                                   Salary = @Salary
                               WHERE UserID = @UserID"; //  Crucial: Update based on UserID
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@FullName", user.FullName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", user.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", user.Gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Position", user.Position ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ImagePath", user.ImagePath ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Salary", user.Salary ?? (object)DBNull.Value);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool AddStaff(UserDTO staff)
        {
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.Transaction = transaction;


                    try
                    {
                        // 1. Insert into Users table
                        cmd.CommandText = @"
                         INSERT INTO Users (Username, Password, Role, Status, Email, Available)
                         VALUES (@Username, @Password, @Role, 1, @Email, 1);
                         SELECT SCOPE_IDENTITY();"; // Get the newly generated UserID


                        cmd.Parameters.AddWithValue("@Username", staff.Username); // Use provided username
                        cmd.Parameters.AddWithValue("@Password", staff.Password); // Hash the password!
                        cmd.Parameters.AddWithValue("@Role", staff.Role);
                        cmd.Parameters.AddWithValue("@Email", staff.Username + "@gmail.com"); // You might want to get this from the UI


                        int newUserId = Convert.ToInt32(cmd.ExecuteScalar()); // Get the new UserID
                        cmd.Parameters.Clear(); // Clear parameters for the next command


                        // 2. Insert into Staffs table
                        cmd.CommandText = @"
                         INSERT INTO Staffs (UserID, FullName, Phone, Gender, DateOfBirth, ImagePath, Position, Salary, HireDate)
                         VALUES (@UserID, @FullName, @Phone, @Gender, @DateOfBirth, @ImagePath, @Position, @Salary, @HireDate)";


                        cmd.Parameters.AddWithValue("@UserID", newUserId);
                        cmd.Parameters.AddWithValue("@FullName", staff.FullName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Phone", staff.Phone ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Gender", staff.Gender ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateOfBirth", staff.DateOfBirth);
                        cmd.Parameters.AddWithValue("@ImagePath", staff.ImagePath ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Position", staff.Position ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Salary", staff.Salary ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@HireDate", staff.HireDate);


                        cmd.ExecuteNonQuery();


                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Log the exception
                        return false;
                    }
                }
            }

        }

        public bool UpdateAdmin(UserDTO admin)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    // Update Users table (for Username and Password)
                    cmd.CommandText = @"
                        UPDATE Users
                        SET Username = @Username,
                        Password = CASE WHEN @Password = '' THEN Password ELSE @Password END
                        WHERE UserID = @UserID"; // Only update password if a new one is provided

                    cmd.Parameters.AddWithValue("@UserID", admin.UserID);
                    cmd.Parameters.AddWithValue("@Username", admin.Username);
                    cmd.Parameters.AddWithValue("@Password", admin.Password ?? ""); // Pass empty string if no new password

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    // Update Admins table (for other details)
                    cmd.CommandText = @"
                        UPDATE Admins
                        SET FullName = @FullName,
                            Phone = @Phone,
                            Gender = @Gender,
                            DateOfBirth = @DateOfBirth,
                            ImagePath = @ImagePath
                        WHERE UserID = @UserID";

                    cmd.Parameters.AddWithValue("@UserID", admin.UserID);
                    cmd.Parameters.AddWithValue("@FullName", admin.FullName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", admin.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gender", admin.Gender ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", admin.DateOfBirth ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ImagePath", admin.ImagePath ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Log the exception
                    return false;
                }
            }
        }

        public int GetStaffCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Role = 'Staff'";
                using (SqlCommand cmd = new SqlCommand(query, conn)) // Use 'using' for SqlCommand too
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return 0; // Or throw an exception, log an error, etc.
                    }
                }
            }
        }

        public int GetCustomerCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Role = 'Customer'";
                using (SqlCommand cmd = new SqlCommand(query, conn)) // Use 'using' for SqlCommand too
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return 0; // Or throw an exception, log an error, etc.
                    }
                }
            }
        }
    }
}
