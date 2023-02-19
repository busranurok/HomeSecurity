using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace App1.Classes
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string DeviceToken { get; set; }
        public string DeviceName { get; set; }
        public int UserId { get; set; }
        public DateTime LastLoginDate { get; set; }

        public static void SaveToken(MobileRegistration token)
        {
            string uri = string.Format("{0}:{1}/api/Device", GlobalSettings.serverAddress, GlobalSettings.port);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "POST";

            Stream newStream = request.GetRequestStream();

            byte[] bodyArray = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(token));
            newStream.Write(bodyArray, 0, bodyArray.Length);

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
            }
        }
    }
}