using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using App1.Classes;

namespace App1
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        private SmsManager _smsManager;
        private BroadcastReceiver _smsSentBroadcastReceiver, _smsDeliveredBroadcastReceiver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menu);

            Button btnPanic = FindViewById<Button>(Resource.Id.btnPanic);
            btnPanic.Click += BtnPanic_Click;

            Button btnAlarmOptions = FindViewById<Button>(Resource.Id.btnAlarmOptions);
            btnAlarmOptions.Click += BtnAlarmOptions_Click;

            Button btnPanicOptions = FindViewById<Button>(Resource.Id.btnPanicOptions);
            btnPanicOptions.Click += BtnPanicOptions_Click;

            Button btnLogout = FindViewById<Button>(Resource.Id.btnLogout);
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            StopService(new Intent(this, typeof(LocationControlService)));
            System.Environment.Exit(0);
        }

        private void BtnPanicOptions_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PanicOptionsActivity));
            StartActivity(intent);
        }

        private void BtnAlarmOptions_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AlarmOptionsActivity));
            StartActivity(intent);
        }

        //panic butonuna basıldığında buraya girer
        private void BtnPanic_Click(object sender, EventArgs e)
        {
            try
            {
                //kullanıcı giriş yaparken serverdan gelen panic ayarları parametresine bakılır.
                //Eğer herhangi bir panik ayarlaması yapılmadıysa mesaj gösterilir.
                if (GlobalSettings.panicSettingId==0)
                {
                    Toast.MakeText(this, "Panik butonunu kullanmak için panik seçeneklerinizi oluşturmalısınız", ToastLength.Long).Show();
                    return;
                }

                //panik ayarlaması yapılmış ise kayıtlı kişilere sms gönderilir


                PanicSetting panicSetting = PanicSetting.GetPanicSetting(GlobalSettings.panicSettingId);
                
                if (panicSetting.IsSmsAlarmActive)
                {
                    //kişinin enlem ve boylam bilgileri kullanılarak google api(geolocation) vasıtasyla açık adres elde edilir.
                    string adres = Utilities.AdresBul(GlobalSettings.enlem, GlobalSettings.boylam);


                    //adres bilgisi elde edildikten sonra gerekli kişilere sms atılır.
                    _smsManager = SmsManager.Default;

                    var message = "Acil Durumu\n Güvende olmadığımı düşünüyorum! Bulunduğum Adres:" + adres;
                    var piSent = PendingIntent.GetBroadcast(this, 0, new Intent("SMS_SENT"), 0);
                    var piDelivered = PendingIntent.GetBroadcast(this, 0, new Intent("SMS_DELIVERED"), 0);

                    string phone = string.Empty;

                    if (!string.IsNullOrEmpty(panicSetting.FirstPersonNumber))
                    {
                        phone = "0" + panicSetting.FirstPersonNumber;
                        _smsManager.SendTextMessage(phone, null, message, piSent, piDelivered);
                    }

                    if (!string.IsNullOrEmpty(panicSetting.SecondPersonNumber))
                    {
                        phone = "0" + panicSetting.SecondPersonNumber;

                        _smsManager.SendTextMessage(phone, null, message, piSent, piDelivered);
                    }
                }

                Toast.MakeText(this, "Panik bildiriminiz gönderilmiştir", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Panik bildiriminiz gönderilirken hata oluşmuştur.KOŞ!!!", ToastLength.Short).Show();
            }
        }
    }
}