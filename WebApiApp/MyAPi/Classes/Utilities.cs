using Newtonsoft.Json.Linq;
using SKYPE4COMLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyAPi.Classes
{
    public class Utilities
    {
        public static void BildirimGonder(int userId)

        {
            string token = Device.GetObjects().FirstOrDefault(x=> x.UserId==userId).DeviceToken;
            if (string.IsNullOrEmpty(token))
                return;

            var jGcmData = new JObject();
            var jData = new JObject();

            string message = "Evinizde birileri var!!";

            jData.Add("message", message);
            jGcmData.Add("to", token);
            jGcmData.Add("data", jData);

            var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
            //var url = new Uri("https://android.googleapis.com/gcm/send");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + "{authorizationkey}");

                    Task.WaitAll(client.PostAsync(url,
                        new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"))
                            .ContinueWith(response =>
                            {
                            }));
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void CallAlarm(string number)
        {
            //Skype skype;
            //skype = new SKYPE4COMLib.Skype();
            if (number.Length == 10)
                number = "+90" + number;
            else if (number.Length == 11)
                number = "+9" + number;
            AlertRequest request = new AlertRequest();
            request.AlarmNumber = number;
            request.AlarmParameter = string.Empty;
            request.AlarmType = "CallAlarm";
            request.IsAlerted = false;
            request.Insert();

            //Call call = skype.PlaceCall(number);
        }

        public static void SmsAlarm(string number)
        {
            //var skype = new SKYPE4COMLib.Skype();
            //skype.Timeout = 120 * 1000;

            if (number.Length == 10)
                number = "+90" + number;
            else if (number.Length == 11)
                number = "+9" + number;

            //var smsType = SKYPE4COMLib.TSmsMessageType.smsMessageTypeOutgoing;
            //var message = skype.CreateSms(smsType, number);
            //message.Body = "Acil Durum:Evimde birileri var";
            //message.Send();
            AlertRequest request = new AlertRequest();
            request.AlarmNumber = number;
            request.AlarmParameter = string.Empty;
            request.AlarmType = "SmsAlarm";
            request.IsAlerted = false;
            request.Insert();
        }

        public static void PanicSms(string number,string adres)
        {
            //var skype = new SKYPE4COMLib.Skype();
            //skype.Timeout = 120 * 1000;

            if (number.Length == 10)
                number = "+90" + number;
            else if (number.Length == 11)
                number = "+9" + number;

            //var smsType = SKYPE4COMLib.TSmsMessageType.smsMessageTypeOutgoing;
            //var message = skype.CreateSms(smsType, number);
            //message.Body = "Acil Durum! Güvende olmadığımı hissediyorum.Konum:"+adres;
            //message.Send();
            AlertRequest request = new AlertRequest();
            request.AlarmNumber = number;
            request.AlarmParameter = adres;
            request.AlarmType = "PanicSms";
            request.IsAlerted = false;
            request.Insert();
        }
    }
}