using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Classes;

namespace App1
{
    public class Utilities
    {
        public static double UzaklikHesapla(double enlem1, double boylam1, double enlem2, double boylam2)
        {
            var dunyaninYariCapi = 6371;
            var dLat = RadyanHesapla(enlem2 - enlem1);
            var dLon = RadyanHesapla(boylam2 - boylam1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(RadyanHesapla(enlem1)) * Math.Cos(RadyanHesapla(enlem2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = dunyaninYariCapi * c;

            return d;
        }

        public static double RadyanHesapla(double derece)
        {
            return derece * (Math.PI / 180);
        }

        public static string AdresBul(double enlem, double boylam)
        {
            RootObject address = new RootObject();
            string uri = string.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&key={securekey}", enlem.ToString().Replace(',', '.'), boylam.ToString().Replace(',', '.'));
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                address = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);

            }
            return address.results[0].formatted_address;
        }

        public static void SendMail(string address,string subject,string messageBody,ref string errorMessage)
        {
            try
            {
                var mailInformation = MailInformation.GetInformation();
                var fromAddress = new MailAddress(mailInformation.Address);
                var toAddress = new MailAddress(address);
                string fromPassword = mailInformation.Password;

                var smtp = new SmtpClient();
                smtp.Host = mailInformation.Host;
                smtp.Port = mailInformation.Port;
                smtp.EnableSsl = mailInformation.EnableSSL;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mailInformation.Address, fromPassword);

                var message = new MailMessage();
                message.From = fromAddress;
                message.To.Add(toAddress);
                message.Subject = subject;
                message.Body = messageBody;
                smtp.Send(message);

            }
            catch (Exception ex)
            {
                errorMessage = ex.StackTrace;
            }
        }
    }
}