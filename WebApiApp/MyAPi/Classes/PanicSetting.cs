using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyAPi.Classes
{
    public class PanicSetting
    {
        public int PanicSetttingId { get; set; }
        public string FirstPersonName { get; set; }
        public string FirstPersonNumber { get; set; }
        public string SecondPersonName { get; set; }
        public string SecondPersonNumber { get; set; }
        public bool IsCallAlarmActive { get; set; }
        public bool IsSmsAlarmActive { get; set; }
        public int UserId { get; set; }

        public int GetLastId()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT TOP 1 * FROM [PanicSetting] ORDER BY [PanicSettingId] DESC";

            int id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr["PanicSettingId"]);
                    }
                }
            }
            return id;
        }
        public void InsertDB()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "INSERT INTO [PanicSetting] VALUES(@FirstPersonName,@FirstPersonNumber,@SecondPersonName,@SecondPersonNumber,@IsCallAlarmActive,@IsSmsAlarmActive)";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    cmd.Parameters.AddWithValue("@FirstPersonName", this.FirstPersonName);
                    cmd.Parameters.AddWithValue("@FirstPersonNumber", this.FirstPersonNumber);
                    cmd.Parameters.AddWithValue("@SecondPersonName", this.SecondPersonName);
                    cmd.Parameters.AddWithValue("@SecondPersonNumber", this.SecondPersonNumber);
                    cmd.Parameters.AddWithValue("@IsCallAlarmActive", this.IsCallAlarmActive);
                    cmd.Parameters.AddWithValue("@IsSmsAlarmActive", this.IsSmsAlarmActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateUser(int userid,int settingid)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "UPDATE [User] SET PanicSettingId=@PanicSettingId WHERE UserId=@UserId";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    cmd.Parameters.AddWithValue("@PanicSettingId", settingid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "UPDATE [PanicSetting]  SET FirstPersonName=@FirstPersonName,FirstPersonNumber=@FirstPersonNumber,SecondPersonName=@SecondPersonName,SecondPersonNumber=@SecondPersonNumber,IsCallAlarmActive=@IsCallAlarmActive,IsSmsAlarmActive=@IsSmsAlarmActive WHERE PanicSettingId=@PanicSettingId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@PanicSettingId", this.PanicSetttingId);
                    cmd.Parameters.AddWithValue("@FirstPersonName", this.FirstPersonName);
                    cmd.Parameters.AddWithValue("@FirstPersonNumber", this.FirstPersonNumber);
                    cmd.Parameters.AddWithValue("@SecondPersonName", this.SecondPersonName);
                    cmd.Parameters.AddWithValue("@SecondPersonNumber", this.SecondPersonNumber);
                    cmd.Parameters.AddWithValue("@IsCallAlarmActive", this.IsCallAlarmActive);
                    cmd.Parameters.AddWithValue("@IsSmsAlarmActive", this.IsSmsAlarmActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<PanicSetting> GetObjects()
        {
            var items = new List<PanicSetting>();

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM [PanicSetting]";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new PanicSetting();
                        item.FirstPersonName = dr["FirstPersonName"] != DBNull.Value ? dr["FirstPersonName"].ToString():string.Empty;
                        item.FirstPersonNumber = dr["FirstPersonNumber"] != DBNull.Value ? dr["FirstPersonNumber"].ToString() : string.Empty;
                        item.IsCallAlarmActive = dr["IsCallAlarmActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsCallAlarmActive"]) : false;
                        item.IsSmsAlarmActive = dr["IsSmsAlarmActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsSmsAlarmActive"]) : false;
                        item.PanicSetttingId = Convert.ToInt32(dr["PanicSettingId"]);
                        item.SecondPersonName = dr["SecondPersonName"] != DBNull.Value ? dr["SecondPersonName"].ToString() : string.Empty;
                        item.SecondPersonNumber = dr["SecondPersonNumber"] != DBNull.Value ? dr["SecondPersonNumber"].ToString() : string.Empty;

                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}