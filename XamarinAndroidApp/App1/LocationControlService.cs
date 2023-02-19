using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
//using App1.Classes;

namespace App1
{
    [Service(Enabled = true)]
    public class LocationControlService : Service, Android.Locations.ILocationListener
    {
        public const double evEnlem = 40.84814;
        public const double evBoylam = 29.42582;
        static readonly string TAG = "X:" + typeof(LocationControlService).Name;
        bool isStarted = false;
        LocationManager _locationManager;
        Location birOncekiKonum;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            Toast.MakeText(this, "Servis durduruldu...", ToastLength.Short).Show();
        }
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {

            Intent resultIntent = new Intent(this, typeof(MainActivity));
            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
            stackBuilder.AddNextIntent(resultIntent);

            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);

            var notification = new Notification.Builder(this)
          .SetContentTitle("Konum kontrol")
          .SetContentText("Konum servisi çalışmaya devam ediyor...")
          .SetSmallIcon(Resource.Drawable.abc_btn_borderless_material)
          .SetContentIntent(resultPendingIntent)
          .SetOngoing(true)
          //.AddAction(BuildRestartTimerAction())
          //.AddAction(BuildStopServiceAction())
          .Build();

            int interval = 1000 * 60 * 3;

            StartForeground(10000, notification);

            _locationManager = (LocationManager)GetSystemService(LocationService);
            if (_locationManager.AllProviders.Contains(LocationManager.NetworkProvider) && _locationManager.IsProviderEnabled(LocationManager.NetworkProvider))
            {
                _locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, interval, 0, this);
            }
            return StartCommandResult.Sticky;

        }
        public override void OnCreate()
        {
            base.OnCreate();
            Log.Debug(TAG, "Servis Oluşturuldu");
        }

        public async void OnLocationChanged(Location location)
        {

            //Toast.MakeText(this, "konum değşikliği", ToastLength.Short).Show();
            GlobalSettings.enlem = location.Latitude;
            GlobalSettings.boylam = location.Longitude;
            if (GlobalSettings.distanceValue!=0)
            {
                if (birOncekiKonum != null)
                {
                    double birOncekiKonumaUzaklikKm = Utilities.UzaklikHesapla(location.Latitude, location.Longitude, birOncekiKonum.Latitude, birOncekiKonum.Longitude);
                    double birOncekiKonumaUzaklikMetre = birOncekiKonumaUzaklikKm * 1000;
                    double EveUzaklik = Utilities.UzaklikHesapla(evEnlem, evBoylam, location.Latitude, location.Longitude);
                    double EveUzaklikMetre = EveUzaklik * 1000;
                    double birOncekiKonumunEveUzakligi = Utilities.UzaklikHesapla(birOncekiKonum.Latitude, birOncekiKonum.Longitude, evEnlem, evBoylam);
                    if (birOncekiKonumaUzaklikMetre > 1)
                    {
                        Intent resultIntent = new Intent(this, typeof(MainActivity));
                        TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
                        stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
                        stackBuilder.AddNextIntent(resultIntent);

                        PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);

                        if (birOncekiKonumunEveUzakligi*1000 < GlobalSettings.distanceValue && EveUzaklik > GlobalSettings.distanceValue)
                        {

                            //var notification = new Notification.Builder(this)
                            //.SetContentTitle("Alarm Kontrol")
                            //.SetContentText("Alarmınızı Aktif Etmek İster Misiniz ?")
                            //.SetSmallIcon(Resource.Drawable.abc_btn_default_mtrl_shape)
                            //.SetContentIntent(resultPendingIntent)
                            //.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate);

                            //var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
                            //notificationManager.Notify(996, notification.Build());

                            //alarmı etkinleştirmediniz !! etkinleştirmek için lütfen uygulamaya giriş yapınız.

                            string subject = "Alarm Aktif Değil!";
                            string body = "Alarm sisteminiz aktif olmadığı halde evden uzaklaştığınız tespit edilmiştir.Alarmı etkinleştirmek isterseniz uygulama üzerinden bu işlemi gerçekleştirebilirsiniz.";
                            string errorMessage = string.Empty;

                            Utilities.SendMail(GlobalSettings.email, subject, body,ref errorMessage);

                        }
                    }
                }
                birOncekiKonum = location;
            }
        }
        public void OnProviderDisabled(string provider)
        {
        }
        public void OnProviderEnabled(string provider)
        {
        }
        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }
        public void StartLocationUpdates()
        {
            Criteria criteriaForGPSService = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Medium
            };

            var locationProvider = _locationManager.GetBestProvider(criteriaForGPSService, true);
            _locationManager.RequestLocationUpdates(locationProvider, 5000, 0, this);

        }
    }
}