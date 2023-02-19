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

namespace App1.Classes
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

        public static MailInformation GetInformation()
        {
            MailInformation information = new MailInformation();
            string uri = string.Format("{0}:{1}/api/MailInformation",GlobalSettings.serverAddress,GlobalSettings.port);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + GlobalSettings.accessToken);

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                information = Newtonsoft.Json.JsonConvert.DeserializeObject<MailInformation>(json);
            }
            return information;
        }
    }
}