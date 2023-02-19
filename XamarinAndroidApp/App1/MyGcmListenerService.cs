//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.Gms.Gcm;
//using Android.Media;
//using Android.OS;
//using Android.Runtime;
//using Android.Util;
//using Android.Views;
//using Android.Widget;

//namespace App1
//{
//    [BroadcastReceiver]
//    public class MyGcmListenerService : GcmListenerService
//    {
//        //public override void OnReceive(Context context, Intent intent)
//        //{
//        //    Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
//        //}
//        public override void OnMessageReceived(string from, Bundle data)
//        {
//            var message = data.GetString("message");
//            Log.Debug("MyGcmListenerService", "From:    " + from);
//            Log.Debug("MyGcmListenerService", "Message: " + message);
//            SendNotification(message);
//        }
//        public void SendNotification(string message)
//        {
//            string[] values = message.Split('~');

//            Bundle valuesForActivity = new Bundle();
//            valuesForActivity.PutString("id", values[0]);
//            valuesForActivity.PutString("email", values[1]);
//            Intent resultIntent = new Intent(this, typeof(MainActivity));
//            resultIntent.PutExtras(valuesForActivity);

//            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
//            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
//            stackBuilder.AddNextIntent(resultIntent);

//            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);

//            var intent = new Intent(this, typeof(MainActivity));
//            intent.AddFlags(ActivityFlags.ClearTop);
//            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);



//            if (values.Length == 4)
//            {
//                //string pathToPushSound = "android.resource://" + this.ApplicationContext.PackageName + "/raw/magic";
//                //Android.Net.Uri soundUri = Android.Net.Uri.Parse(pathToPushSound);

//                var notificationBuilder = new Notification.Builder(this)
//               .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
//               .SetSmallIcon(Resource.Drawable.abc_ic_star_black_16dp)
//               .SetContentTitle("Güvenlik Sistemi")
//               .SetContentText("Atamýþ Olduðunuz Görev Tamamlandı.")
//               .SetAutoCancel(true)
//               .SetContentIntent(resultPendingIntent);
//                //.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate);

//                var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
//                notificationManager.Notify(1, notificationBuilder.Build());
//            }
//            else
//            {
//                var notificationBuilder = new Notification.Builder(this)
//               .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
//               .SetSmallIcon(Resource.Drawable.abc_ic_star_black_16dp)
//               .SetContentTitle("Güvenlik Sistemi")
//               .SetContentText(values[2])
//               .SetAutoCancel(true)
//               .SetContentIntent(resultPendingIntent)
//               .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate);

//                var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
//                notificationManager.Notify(1, notificationBuilder.Build());
//            }

//        }
//    }
//}