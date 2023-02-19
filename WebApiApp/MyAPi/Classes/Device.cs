using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyAPi.Classes
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string DeviceToken { get; set; }
        public string DeviceName { get; set; }
        public int UserId { get; set; }
        public DateTime LastLoginDate { get; set; }


        public void InsertDB()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "INSERT INTO [Device](DeviceToken,DeviceName,UserId,LastLoginDate) VALUES(@DeviceToken,@DeviceName,@UserId,@LastLoginDate)";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    cmd.Parameters.AddWithValue("@DeviceToken", this.DeviceToken);
                    cmd.Parameters.AddWithValue("@DeviceName", this.DeviceName);
                    cmd.Parameters.AddWithValue("@UserId", this.UserId);
                    cmd.Parameters.AddWithValue("@LastLoginDate", this.LastLoginDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "UPDATE [Device] SET DeviceToken=@DeviceToken,DeviceName=@DeviceName,UserId=@UserId,LastLoginDate=@LastLoginDate WHERE DeviceId=@DeviceId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@DeviceId", this.DeviceId);
                    cmd.Parameters.AddWithValue("@DeviceToken", this.DeviceToken);
                    cmd.Parameters.AddWithValue("@DeviceName", this.DeviceName);
                    cmd.Parameters.AddWithValue("@UserId", this.UserId);
                    cmd.Parameters.AddWithValue("@LastLoginDate", this.LastLoginDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Device> GetObjects()
        {
            var items = new List<Device>();

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM [Device]";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Device item = new Device();
                        item.DeviceId = Convert.ToInt32(dr["DeviceId"]);
                        item.DeviceName = dr["DeviceName"] != DBNull.Value ? dr["DeviceName"].ToString() : string.Empty;
                        item.DeviceToken = dr["DeviceToken"] != DBNull.Value ? dr["DeviceToken"].ToString() : string.Empty;
                        item.LastLoginDate = dr["LastLoginDate"] != DBNull.Value ? Convert.ToDateTime(dr["LastLoginDate"]) : DateTime.MinValue;
                        item.UserId = dr["UserId"] != null ? Convert.ToInt32(dr["UserId"]) : default(int);

                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}