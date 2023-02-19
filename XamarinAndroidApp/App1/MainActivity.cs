using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Telephony;
using Android.Util;
using Android.Views;
using Android.Widget;
using App1.Classes;
using Firebase;
using Firebase.Iid;
using Firebase.Messaging;
using Gcm.Client;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        EditText txtUsername;
        EditText txtPassword;
        private SmsManager _smsManager;
        private BroadcastReceiver _smsSentBroadcastReceiver, _smsDeliveredBroadcastReceiver;
        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

            Button button = FindViewById<Button>(Resource.Id.btnLogin);
            button.Click += btnGiris_Click;

            txtUsername = FindViewById<EditText>(Resource.Id.txtKullaniciAdi);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            Intent servIntent = new Intent(ApplicationContext, typeof(LocationControlService));
            StartService(servIntent);

            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);
            Firebase.FirebaseApp.InitializeApp(this);
            Thread.Sleep(1000);

            //FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //         fab.Click += FabOnClick;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            AccessToken.GetAuthorizationAccessToken(txtUsername.Text,txtPassword.Text);

            // User class'ı içerisindeki GetUser metoduna kullanıcının girmiş olduğunu kullanıcı adı ve şifre gönderilir.
            //GetUser metodu Web API ye giderek bu bilgilere sahip bir kullanıcı var mı diye sorgular
            User loggedOnUser = User.GetUser(txtUsername.Text, txtPassword.Text);
            //bu bilgilere ait bir kullanıcı var ise Sisteme giriş yapılır
            if (loggedOnUser != null)
            {
                //kullanıcının bilgileri GlobalSettings classındaki değişkenlerde tutulur.Böylelikle başka yerlerde de ihtiyacmımız olduğunda GlobalSettings.userId vs diyerek ulaşabiliriz bu bilgilere.
                GlobalSettings.userId = loggedOnUser.UserId;
                GlobalSettings.username = loggedOnUser.Username;
                GlobalSettings.panicSettingId = loggedOnUser.PanicSettingId;
                GlobalSettings.alarmSettingId = loggedOnUser.AlarmSettingId;
                GlobalSettings.email = loggedOnUser.Email;

                if (loggedOnUser.AlarmSettingId != 0)
                {
                    AlarmSetting setting = AlarmSetting.GetAlarmSetting(loggedOnUser.AlarmSettingId);
                    GlobalSettings.distanceValue = setting.DistanceValue;
                }


                IsPlayServicesAvailable();
                //İkinci sayfaya geçilir(MenuActivity sayfasına)
                Intent intent = new Intent(this, typeof(MenuActivity));
                StartActivity(intent);


            }
            //Bu bilgilere ait kullanıcı yok ise hata mesajı gösterilir.
            else
            {
                Toast.MakeText(this, "Bilgiler Hatalı", ToastLength.Short).Show();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        //public void IsPlayServiceAvailable()
        //{
        //    int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
        //    if (resultCode != ConnectionResult.Success)
        //    {
        //        if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
        //        {
        //            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
        //            builder.SetTitle("Bilgi");
        //            builder.SetMessage(GoogleApiAvailability.Instance.GetErrorString(resultCode));
        //            Dialog dialog = builder.Create();
        //            dialog.Show();
        //        }
        //        else
        //        {
        //            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
        //            builder.SetTitle("Bilgi");
        //            builder.SetMessage("Cihaz Desteklemiyor!!!!!!!");
        //            Dialog dialog = builder.Create();
        //            dialog.Show();
        //            Finish();
        //        }
        //    }
        //    else
        //    {
        //        var intent = new Intent(this, typeof(RegistrationIntentService));
        //        StartService(intent);
        //    }
        //}

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {

                }
                    //msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    //msgText.Text = "This device is not supported";
                    Finish();
                }
                return false;
            }
            else
            {
                var intent = new Intent(this, typeof(MyFirebaseIIDService));
                StartService(intent);
                //msgText.Text = "Google Play Services is available.";
                return true;
            }
        }
    }
}

