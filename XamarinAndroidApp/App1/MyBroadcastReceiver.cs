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
using App1.Classes;
using Gcm.Client;

[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

//GET_ACCOUNTS is needed only for Android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]
namespace App1
{
    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE },
      Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK },
      Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY },
      Categories = new string[] { "@PACKAGE_NAME@" })]
    public class MyBroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
    {
        public static string[] SENDER_IDS = new string[] { "576571102167" };

        public const string TAG = "MyBroadcastReceiver-GCM";
    }

    [Service]
    public class PushHandlerService : GcmServiceBase
    {
        public PushHandlerService() : base(MyBroadcastReceiver.SENDER_IDS) { }

        const string TAG = "GCM-SAMPLE";

        protected override void OnRegistered(Context context, string registrationId)
        {
            //SmtpClient smtp = new SmtpClient();
            //smtp.Credentials = new NetworkCredential("hasan@ihsan.com.tr", "hasan1103993");
            //smtp.Host = "mail.ihsan.com.tr";
            //smtp.Port = 587;
            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("hasan@ihsan.com.tr");
            //mail.To.Add("hasan@ihsan.com.tr");
            //mail.Subject = "Konu";
            //mail.Body = registrationId;
            //smtp.Send(mail);


            //MobileRegistration register = new MobileRegistration();
            //register.Token = registrationId;
            //register.Email = ProgramBilgileri.currentUserEmail;
            //register.Process = "Register";
            //new TokenHelper().Save(register).Wait();
        }

        protected override void OnUnRegistered(Context context, string registrationId)
        {

            //MobileRegistration register = new MobileRegistration();
            //register.Token = registrationId;
            //register.Email = ProgramBilgileri.currentUserEmail;
            //register.Process = "Unregister";
            //new TokenHelper().Save(register).Wait();

        }
        protected override void OnMessage(Context context, Intent intent)
        {
            //var msg = new StringBuilder();

            //if (intent != null && intent.Extras != null)
            //{
            //    foreach (var key in intent.Extras.KeySet())
            //        msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            //}

            //var prefs = GetSharedPreferences(context.PackageName, FileCreationMode.Private);
            //var edit = prefs.Edit();
            //edit.PutString("last_msg", msg.ToString());
            //edit.Commit();
        }

        protected override bool OnRecoverableError(Context context, string errorId)
        {
            return base.OnRecoverableError(context, errorId);
        }
        protected override void OnError(Context context, string errorId)
        {
        }
        void createNotification(string title, string desc)
        {
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
            var uiIntent = new Intent(this, typeof(MainActivity));
            var notification = new Notification(Android.Resource.Drawable.SymActionEmail, title);
            notification.Flags = NotificationFlags.AutoCancel;
            notification.SetLatestEventInfo(this, title, desc, PendingIntent.GetActivity(this, 0, uiIntent, 0));
            notificationManager.Notify(1, notification);
        }
    }
}