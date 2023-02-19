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

        public AlarmSetting Save()
        {
            string uri = string.Format("{0}:{1}/api/AlarmSetting", GlobalSettings.serverAddress, GlobalSettings.port);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + GlobalSettings.accessToken);

            Stream newStream = request.GetRequestStream();

            byte[] bodyArray = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(this));
            newStream.Write(bodyArray, 0, bodyArray.Length);

            AlarmSetting setting = new AlarmSetting();

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                setting = JsonConvert.DeserializeObject<AlarmSetting>(json);
                GlobalSettings.alarmSettingId = setting.AlarmSettingId;
            }
            return setting;
        }

        public static AlarmSetting GetAlarmSetting(int alarmSettingId)
        {
            AlarmSetting setting = new AlarmSetting();
            string uri = string.Format("{0}:{1}/api/AlarmSetting?alarmSettingId={2}", GlobalSettings.serverAddress, GlobalSettings.port, alarmSettingId);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + GlobalSettings.accessToken);

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                setting = Newtonsoft.Json.JsonConvert.DeserializeObject<AlarmSetting>(json);

            }
            return setting;
        }
    }
}
