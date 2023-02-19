//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.Gms.Gcm;
//using Android.Gms.Iid;
//using Android.OS;
//using Android.Runtime;
//using Android.Util;
//using Android.Views;
//using Android.Widget;
//using App1.Classes;

//namespace App1
//{
//    [Service(Exported = false)]
//    class RegistrationIntentService : IntentService
//    {

//        static object locker = new object();
//        public RegistrationIntentService() : base("RegistrationIntentService") { }
//        protected void OnRegistered(Context context, string registrationId)
//        {
//            AlertDialog.Builder builder = new AlertDialog.Builder(this);
//            builder.SetTitle(registrationId);
//            Dialog dialog = builder.Create();
//            dialog.Show();
//            Console.WriteLine("Device Id:" + registrationId);
//        }
//        protected override void OnHandleIntent(Intent intent)
//        {
//            try
//            {
//                Log.Info("RegistrationIntentService", "Calling InstanceID.GetToken");
//                lock (locker)
//                {
//                    var instanceID = InstanceID.GetInstance(this);
//                    var token = instanceID.GetToken("576571102167", GoogleCloudMessaging.InstanceIdScope, null);

//                    Log.Info("RegistrationIntentService", "GCM Registration Token: " + token);
//                    SendRegistrationToAppServer(token);
//                    Subscribe(token);
//                }
//            }
//            catch (Exception e)
//            {
//                Log.Debug("RegistrationIntentService", "Failed to get a registration token");
//                return;
//            }
//        }

//        void SendRegistrationToAppServer(string token)
//        {
//            try
//            {
//                string username = GlobalSettings.username;
//                if (!string.IsNullOrEmpty(username))
//                {
//                    MobileRegistration tok = new MobileRegistration();
//                    tok.Username = username; ;
//                    tok.Token = token;
//                    Classes.Device.SaveToken(tok);

//                    //tok.Process = "Register";
//                    //new TokenHelper().Save(tok).Wait();
//                }
//            }
//            catch (Exception ex)
//            {
//                AlertDialog.Builder builder = new AlertDialog.Builder(this);
//                builder.SetTitle(ex.Message);
//                Dialog dialog = builder.Create();
//                dialog.Show();
//            }
//        }

//        void Subscribe(string token)
//        {
//            var pubSub = GcmPubSub.GetInstance(this);
//            pubSub.Subscribe(token, "/topics/global", null);
//        }
//    }
//}