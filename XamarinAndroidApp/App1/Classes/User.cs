using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Classes
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

        public static User GetUser(string username, string password)
        {
            User user = new User();
            string uri = string.Format("{0}:{1}/api/User?username={2}&password={3}", GlobalSettings.serverAddress, GlobalSettings.port,username,password);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + GlobalSettings.accessToken);

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);

                //MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                //byte[] arySifre = Encoding.UTF8.GetBytes(password);
                //byte[] aryHash = provider.ComputeHash(arySifre);
                //string sifre = BitConverter.ToString(aryHash);

                //if (user != null)
                //{
                //    if (string.IsNullOrEmpty(user.Password) || user.Password != sifre)
                //        user = null;
                //}
            }
            return user;
        }
    }
}