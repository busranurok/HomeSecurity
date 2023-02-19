using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyAPi.Classes
{
    public class MailInformation
    {
        public int MailInformationId { get; set; }
        public string Address { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }

        public void InsertDB()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "INSERT INTO MailInformation(Address,Host,EnableSSL,Port,Username,Password)";


            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@Address", this.Address);
                    cmd.Parameters.AddWithValue("@Host", this.Host);
                    cmd.Parameters.AddWithValue("@Password", this.Password);
                    cmd.Parameters.AddWithValue("@Port", this.Port);
                    cmd.Parameters.AddWithValue("@Username", this.Username);
                    cmd.Parameters.AddWithValue("@EnableSSL", this.EnableSSL);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "UPDATE MailInformation SET Address=@Address,Host=@Host,EnableSSL=@EnableSSL,Port=@Port,Username=@Username,Password=Password WHERE  MailInformationId=@MailInformationId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@Address", this.Address);
                    cmd.Parameters.AddWithValue("@Host", this.Host);
                    cmd.Parameters.AddWithValue("@Password", this.Password);
                    cmd.Parameters.AddWithValue("@Port", this.Port);
                    cmd.Parameters.AddWithValue("@Username", this.Username);
                    cmd.Parameters.AddWithValue("@EnableSSL", this.EnableSSL);
                    cmd.Parameters.AddWithValue("MailInformationId", this.MailInformationId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<MailInformation> GetObjects()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM MailInformation";

            var items = new List<MailInformation>();

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var item = new MailInformation();
                        item.Address = dr["Address"].ToString();
                        item.EnableSSL = Convert.ToBoolean(dr["EnableSSL"]);
                        item.Host = dr["Host"].ToString();
                        item.MailInformationId = Convert.ToInt32(dr["MailInformationId"]);
                        item.Password = dr["Password"].ToString();
                        item.Port = Convert.ToInt32(dr["Port"]);
                        item.Username = dr["Username"].ToString();

                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public void Delete()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "DELETE FROM MailInformation WHERE MailInformationId=@MailInformationId ";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    cmd.Parameters.AddWithValue("@MailInformationId", this.MailInformationId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}