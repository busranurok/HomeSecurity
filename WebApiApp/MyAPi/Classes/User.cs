using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace MyAPi.Classes
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
        public string Email { get; set; }


        public static List<User> GetObjects()
        {
            var items = new List<User>();

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM [User]";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
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
                        item.Email = dr["Email"] != DBNull.Value ? dr["Email"].ToString() : string.Empty;

                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public static User GetUser(string username,string password)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM [User] WHERE Username=@Username AND Password=@Password";

            User item = null;

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        item = new User();
                        item.AlarmSettingId = dr["AlertSettingId"] != DBNull.Value ? Convert.ToInt32(dr["AlertSettingId"]) : default(int);
                        item.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : string.Empty;
                        item.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : string.Empty;
                        item.PanicSettingId = dr["PanicSettingId"] != DBNull.Value ? Convert.ToInt32(dr["PanicSettingId"]) : default(int);
                        item.Password = dr["Password"] != DBNull.Value ? dr["Password"].ToString() : string.Empty;
                        item.UserId = Convert.ToInt32(dr["UserId"]);
                        item.Username = dr["Username"].ToString();
                        item.Email = dr["Email"] != DBNull.Value ? dr["Email"].ToString() : string.Empty;

                    }
                }
                return item;
            }
        }
    }
}