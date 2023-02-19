using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuvenlikDesktop.Classes
{
    public class AlertRequest
    {
        public int AlarmRequestId { get; set; }
        public string AlarmType { get; set; }
        public string AlarmNumber { get; set; }
        public string AlarmParameter { get; set; }
        public bool IsAlerted { get; set; }


        public static List<AlertRequest> GetNonCompletedAlarms()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM AlertRequest WHERE IsAlerted=0";

            var items = new List<AlertRequest>();

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AlertRequest item = new AlertRequest();
                        item.AlarmNumber = dr["AlarmNumber"] != DBNull.Value ? dr["AlarmNumber"].ToString() : string.Empty;
                        item.AlarmParameter = dr["AlarmParameter"] != DBNull.Value ? dr["AlarmParameter"].ToString() : string.Empty;
                        item.AlarmRequestId = Convert.ToInt32(dr["AlarmRequestId"]);
                        item.AlarmType = dr["AlarmType"] != DBNull.Value ? dr["AlarmType"].ToString() : string.Empty;

                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public static void Update(int alarmRequestId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "UPDATE AlertRequest SET IsAlerted=1 WHERE AlarmRequestId=@AlarmRequestId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@AlarmRequestId", alarmRequestId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Insert()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "INSERT INTO AlertRequest(AlarmType,AlarmNumber,AlarmParameter,IsAlerted) VALUES(@AlarmType,@AlarmNumber,@AlarmParameter,@IsAlerted)";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@AlarmType", this.AlarmType);
                    cmd.Parameters.AddWithValue("@AlarmNumber", this.AlarmNumber);
                    cmd.Parameters.AddWithValue("@AlarmParameter", this.AlarmParameter);
                    cmd.Parameters.AddWithValue("@IsAlerted", this.IsAlerted);

                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
