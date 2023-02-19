using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace MyAPi.Classes
{
    public class AlarmSetting
    {
        public int AlarmSettingId { get; set; }
        public string FirstPersonName { get; set; }
        public string FirstPersonNumber { get; set; }
        public string SecondPersonName { get; set; }
        public string SecondPersonNumber { get; set; }
        public bool IsActiveDistanceAlarm { get; set; }
        public double DistanceValue { get; set; }
        public bool IsCallAlarmActive { get; set; }
        public bool IsSmsAlarmActive { get; set; }
        public bool IsPoliceAlarmActive { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }

        public void InsertDB()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "INSERT INTO [AlarmSetting] VALUES(@FirstPersonName,@FirstPersonNumber,@SecondPersonName,@SecondPersonNumber,@IsActiveDistanceAlarm,@DistanceValue,@IsCallAlarmActive,@IsSmsAlarmActive,@IsPoliceAlarmActive,@IsActive)";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@IsActiveDistanceAlarm", this.IsActiveDistanceAlarm);
                    cmd.Parameters.AddWithValue("@DistanceValue", this.DistanceValue);
                    cmd.Parameters.AddWithValue("@FirstPersonName", this.FirstPersonName);
                    cmd.Parameters.AddWithValue("@FirstPersonNumber", this.FirstPersonNumber);
                    cmd.Parameters.AddWithValue("@SecondPersonName", this.SecondPersonName);
                    cmd.Parameters.AddWithValue("@SecondPersonNumber", this.SecondPersonNumber);
                    cmd.Parameters.AddWithValue("@IsCallAlarmActive", this.IsCallAlarmActive);
                    cmd.Parameters.AddWithValue("@IsSmsAlarmActive", this.IsSmsAlarmActive);
                    cmd.Parameters.AddWithValue("@IsPoliceAlarmActive", this.IsPoliceAlarmActive);
                    cmd.Parameters.AddWithValue("@IsActive", this.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int GetLastId()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT TOP 1 * FROM [AlarmSetting] ORDER BY [AlarmSettingId] DESC";

            int id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr["AlarmSettingId"]);
                    }
                }
            }
            return id;
        }
        public void UpdateUser(int userid, int settingid)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "UPDATE [User] SET PanicSettingId=@AlertSettingId WHERE UserId=@UserId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    cmd.Parameters.AddWithValue("@AlertSettingId", settingid);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = @"UPDATE [AlarmSetting] SET FirstPersonName=@FirstPersonName,
FirstPersonNumber=@FirstPersonNumber,
SecondPersonName=@SecondPersonName,
SecondPersonNumber=@SecondPersonNumber,
IsActiveDistanceAlarm=@IsActiveDistanceAlarm,
DistanceValue=@DistanceValue,
IsCallAlarmActive=@IsCallAlarmActive,
IsSmsAlarmActive=@IsSmsAlarmActive,
IsPoliceAlarmActive=@IsPoliceAlarmActive,
IsActive=@IsActive 
WHERE AlarmSettingId=@AlarmSettingId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@AlarmSettingId", this.AlarmSettingId);
                    cmd.Parameters.AddWithValue("@IsActiveDistanceAlarm", this.IsActiveDistanceAlarm);
                    cmd.Parameters.AddWithValue("@DistanceValue", this.DistanceValue);
                    cmd.Parameters.AddWithValue("@FirstPersonName", this.FirstPersonName);
                    cmd.Parameters.AddWithValue("@FirstPersonNumber", this.FirstPersonNumber);
                    cmd.Parameters.AddWithValue("@SecondPersonName", this.SecondPersonName);
                    cmd.Parameters.AddWithValue("@SecondPersonNumber", this.SecondPersonNumber);
                    cmd.Parameters.AddWithValue("@IsCallAlarmActive", this.IsCallAlarmActive);
                    cmd.Parameters.AddWithValue("@IsSmsAlarmActive", this.IsSmsAlarmActive);
                    cmd.Parameters.AddWithValue("@IsPoliceAlarmActive", this.IsPoliceAlarmActive);
                    cmd.Parameters.AddWithValue("@IsActive", this.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<AlarmSetting> GetObjects()
        {
            var items = new List<AlarmSetting>();

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM [AlarmSetting]";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new AlarmSetting();
                        item.AlarmSettingId = Convert.ToInt32(dr["AlarmSettingId"]);
                        item.DistanceValue = dr["DistanceValue"] != DBNull.Value ? Convert.ToDouble(dr["DistanceValue"]) : default(double);
                        item.IsActive = dr["IsActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsActive"]) : false;
                        item.IsActiveDistanceAlarm = dr["IsActiveDistanceAlarm"] != DBNull.Value ? Convert.ToBoolean(dr["IsActiveDistanceAlarm"]) : false;
                        item.IsPoliceAlarmActive = dr["IsPoliceAlarmActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsPoliceAlarmActive"]) : false;
                        item.FirstPersonName = dr["FirstPersonName"] != DBNull.Value ? dr["FirstPersonName"].ToString() : string.Empty;
                        item.FirstPersonNumber = dr["FirstPersonNumber"] != DBNull.Value ? dr["FirstPersonNumber"].ToString() : string.Empty;
                        item.IsCallAlarmActive = dr["IsCallAlarmActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsCallAlarmActive"]) : false;
                        item.IsSmsAlarmActive = dr["IsSmsAlarmActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsSmsAlarmActive"]) : false;
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