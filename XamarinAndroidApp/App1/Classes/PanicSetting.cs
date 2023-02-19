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

        public PanicSetting Save()
        {
            string uri = string.Format("{0}:{1}/api/PanicSetting",GlobalSettings.serverAddress,GlobalSettings.port);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + GlobalSettings.accessToken);

            Stream newStream = request.GetRequestStream();

            byte[] bodyArray = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(this));
            newStream.Write(bodyArray, 0, bodyArray.Length);

            PanicSetting setting = new PanicSetting();

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                setting = JsonConvert.DeserializeObject<PanicSetting>(json);
                GlobalSettings.alarmSettingId = setting.PanicSetttingId;
            }
            return setting;
        }

        public static PanicSetting GetPanicSetting(int panicSettingId)
        {
            PanicSetting setting = new PanicSetting();
            string uri = string.Format("{0}:{1}/api/PanicSetting?panicSettingId={2}", GlobalSettings.serverAddress, GlobalSettings.port, panicSettingId);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + GlobalSettings.accessToken);

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                setting = Newtonsoft.Json.JsonConvert.DeserializeObject<PanicSetting>(json);

            }
            return setting;
        }

        public static void Panic(string number,string address)
        {
            string uri = string.Format("{0}:{1}/api/Panic?number={2}&address={3}", GlobalSettings.serverAddress, GlobalSettings.port,number,address);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + GlobalSettings.accessToken);

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();

            }
        }
    }
}