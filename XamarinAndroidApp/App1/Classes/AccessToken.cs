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
    public class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        public static void GetAuthorizationAccessToken(string username, string password)
        {
            string uri = string.Format("{0}:{1}/token",GlobalSettings.serverAddress,GlobalSettings.port);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.Accept = "application/json";

            Stream newStream = request.GetRequestStream();
            string bodyString = "grant_type=password&username=" + "Hasan" + "&password=" + "123";

            byte[] bodyArray = Encoding.ASCII.GetBytes(bodyString);

            newStream.Write(bodyArray, 0, bodyArray.Length);

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                AccessToken token = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessToken>(json);
                GlobalSettings.accessToken = token.access_token;
            }

        }
    }
}