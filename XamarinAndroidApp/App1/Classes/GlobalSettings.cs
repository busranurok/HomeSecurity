using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class GlobalSettings
    {
        public static string username = String.Empty;
        public static int userId = 0;
        public static string email = String.Empty;
        public static int alarmSettingId = 0;
        public static int panicSettingId = 0;
        public static string serverAddress = "http://apiserver";
        public static int port = 80;
        public static double enlem=0;
        public static double boylam=0;
        public static double distanceValue = 0;
        public static string accessToken = string.Empty;
    }
}