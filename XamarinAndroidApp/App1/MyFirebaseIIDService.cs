using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using App1.Classes;
using Firebase.Iid;

namespace App1
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }
        
        void SendRegistrationToServer(string token)
        {
            try
            {
                string username = GlobalSettings.username;
                if (!string.IsNullOrEmpty(username))
                {
                    MobileRegistration tok = new MobileRegistration();
                    tok.Username = username; ;
                    tok.Token = token;
                    Classes.Device.SaveToken(tok);

                    //tok.Process = "Register";
                    //new TokenHelper().Save(tok).Wait();
                }
            }
            catch (Exception ex)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle(ex.Message);
                Dialog dialog = builder.Create();
                dialog.Show();
            }
        }
        //protected override void OnHandleIntent(Intent intent)
        //{
        //    try
        //    {
        //        Log.Info("RegistrationIntentService", "Calling InstanceID.GetToken");
        //        lock (locker)
        //        {
        //            var instanceID = InstanceID.GetInstance(this);
        //            var token = instanceID.GetToken("576571102167", GoogleCloudMessaging.InstanceIdScope, null);

        //            Log.Info("RegistrationIntentService", "GCM Registration Token: " + token);
        //            SendRegistrationToAppServer(token);
        //            Subscribe(token);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Debug("RegistrationIntentService", "Failed to get a registration token");
        //        return;
        //    }
        //}
    }
}