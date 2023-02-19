using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp56.Classes
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerDescription { get; set; }
        public string CustomerHomeAddress { get; set; }
        public string ModelDirectoryName { get; set; }
        public string ModelFolderName { get; set; }
        public string ModelXmlName { get; set; }

        public void InsertDB()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "INSERT INTO Customer (CustomerName,CustomerDescription,CustomerHomeAddress,ModelDirectoryName,ModelFolderName,ModelXmlName) VALUES (@CustomerName,@CustomerDescription,@CustomerHomeAddress,@ModelDirectoryName,@ModelFolderName,@ModelXmlName)";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd =new SqlCommand(commandString,con))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", this.CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerDescription", this.CustomerDescription);
                    cmd.Parameters.AddWithValue("@CustomerHomeAddress", this.CustomerHomeAddress);
                    cmd.Parameters.AddWithValue("@ModelDirectoryName", this.ModelDirectoryName);
                    cmd.Parameters.AddWithValue("@ModelFolderName", this.ModelFolderName);
                    cmd.Parameters.AddWithValue("@ModelXmlName", this.ModelXmlName);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "UPDATE Customer CustomerName=@CustomerName,CustomerDescription=@CustomerDescription,CustomerHomeAddress=@CustomerHomeAddress,ModelFolderPath=@ModelFolderPath,ModelXmlPath=@ModelXmlPath WHERE CustomerId=@CustomerId";

            using (var con =new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString,con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", this.CustomerId);
                    cmd.Parameters.AddWithValue("@CustomerName", this.CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerDescription", this.CustomerDescription);
                    cmd.Parameters.AddWithValue("@CustomerHomeAddress", this.CustomerHomeAddress);
                    cmd.Parameters.AddWithValue("@ModelDirectoryName", this.ModelDirectoryName);
                    cmd.Parameters.AddWithValue("@ModelFolderName", this.ModelFolderName);
                    cmd.Parameters.AddWithValue("@ModelXmlName", this.ModelXmlName);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Customer> GetObjects()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM Customer";

            var items = new List<Customer>();

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Customer item = new Customer();
                        item.CustomerDescription = dr["CustomerDescription"].ToString();
                        item.CustomerHomeAddress = dr["CustomerHomeAddress"].ToString();
                        item.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        item.CustomerName = dr["CustomerName"].ToString();
                        item.ModelDirectoryName = dr["ModelDirectoryName"].ToString();
                        item.ModelFolderName = dr["ModelFolderName"].ToString();
                        item.ModelXmlName = dr["ModelXmlName"].ToString() ;

                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public void Delete()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "DELETE FROM Customer WHERE CustomerId=@CustomerId";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", this.CustomerId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Customer GetObjectById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var commandString = "SELECT * FROM Customer WHERE CustomerId=@CustomerId";

            var customer = null;

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(commandString, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        customer= new Customer();
                        customer.CustomerDescription = dr["CustomerDescription"].ToString();
                        customer.CustomerHomeAddress = dr["CustomerHomeAddress"].ToString();
                        customer.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        customer.CustomerName = dr["CustomerName"].ToString();
                        customer.ModelDirectoryName = dr["ModelDirectoryName"].ToString();
                        customer.ModelFolderName = dr["ModelFolderName"].ToString();
                        customer.ModelXmlName = dr["ModelXmlName"].ToString();

                    }
                }
            }
            return customer;
        }
    }
}
