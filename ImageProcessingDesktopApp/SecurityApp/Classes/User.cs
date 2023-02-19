using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuvenlikDesktop.Classes
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PanicSettingId { get; set; }
        public int AlarmSettingId { get; set; }
        public bool IsAdmin { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }

        public static List<User> GetObjects()
        {
            var items = new List<User>();

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM [User]";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new User();
                        item.AlarmSettingId = dr["AlertSettingId"] != DBNull.Value ? Convert.ToInt32(dr["AlertSettingId"]) : default(int);
                        item.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : string.Empty;
                        item.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : string.Empty;
                        item.PanicSettingId = dr["PanicSettingId"] != DBNull.Value ? Convert.ToInt32(dr["PanicSettingId"]) : default(int);
                        item.Password = dr["Password"] != DBNull.Value ? dr["Password"].ToString() : string.Empty;
                        item.UserId = Convert.ToInt32(dr["UserId"]);
                        item.Username = dr["Username"].ToString();
                        item.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
                        item.CustomerId =dr["CustomerId"]!=DBNull.Value ? Convert.ToInt32(dr["CustomerId"]):0;

                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public void Insert()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "INSERT INTO [User] (Username,Password,FirstName,LastName,PanicSettingId,AlertSettingId,Email,CustomerId,IsAdmin) VALUES  (@Username,@Password,@FirstName,@LastName,@PanicSettingId,@AlertSettingId,@Email,@CustomerId,@IsAdmin)";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    cmd.Parameters.AddWithValue("@Username", this.Username);
                    cmd.Parameters.AddWithValue("@Password", this.Password);
                    cmd.Parameters.AddWithValue("@FirstName", this.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", this.LastName);
                    cmd.Parameters.AddWithValue("@PanicSettingId", this.PanicSettingId);
                    cmd.Parameters.AddWithValue("@AlertSettingId", this.AlarmSettingId);
                    cmd.Parameters.AddWithValue("@Email", this.Email);
                    cmd.Parameters.AddWithValue("@CustomerId", this.CustomerId);
                    cmd.Parameters.AddWithValue("@IsAdmin", this.IsAdmin);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "UPDATE [User] SET Username=@Username,Password=@Password,FirstName=@FirstName,LastName=@LastName,PanicSettingId=@PanicSettingId,AlertSettingId=@AlertSettingId,Email=@Email,CustomerId=@CustomerId,IsAdmin=@IsAdmin WHERE UserId=@UserId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", this.UserId);
                    cmd.Parameters.AddWithValue("@Username", this.Username);
                    cmd.Parameters.AddWithValue("@Password", this.Password);
                    cmd.Parameters.AddWithValue("@FirstName", this.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", this.LastName);
                    cmd.Parameters.AddWithValue("@PanicSettingId", this.PanicSettingId);
                    cmd.Parameters.AddWithValue("@AlertSettingId", this.AlarmSettingId);
                    cmd.Parameters.AddWithValue("@Email", this.Email);
                    cmd.Parameters.AddWithValue("@CustomerId", this.CustomerId);
                    cmd.Parameters.AddWithValue("@IsAdmin", this.IsAdmin);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "DELETE FROM [User] WHERE UserId=@UserId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", this.UserId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
