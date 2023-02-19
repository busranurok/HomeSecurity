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

namespace App1
{
    [Activity(Label = "PanicOptionsActivity")]
    public class PanicOptionsActivity : Activity
    {
        EditText txtFirstPersonName;
        EditText txtFirstPersonNumber;
        EditText txtSecondPersonName;
        EditText txtSecondPersonNumber;
        CheckBox chkIsCallAlarmActive;
        CheckBox chkIsSmsAlarmActive;
        PanicSetting willUpdateItem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PanicOptions);

            willUpdateItem = new PanicSetting();
            willUpdateItem.PanicSetttingId = GlobalSettings.panicSettingId;

            Button btn = FindViewById<Button>(Resource.Id.btnSavePanicOption);
            btn.Click += Btn_Click;

            txtFirstPersonName = FindViewById<EditText>(Resource.Id.txtFirstPersonNamePanicOptions);
            txtFirstPersonNumber = FindViewById<EditText>(Resource.Id.txtFirstPersonNumberPanicOptions);
            txtSecondPersonName = FindViewById<EditText>(Resource.Id.txtSecondPersonNamePanicOption);
            txtSecondPersonNumber = FindViewById<EditText>(Resource.Id.txtSecondPersonNumberPanicOption);
            chkIsCallAlarmActive = FindViewById<CheckBox>(Resource.Id.chkAlarmWithCallPanicOption);
            chkIsSmsAlarmActive = FindViewById<CheckBox>(Resource.Id.chkAlarmWithSMSPanicOption);
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            PanicSetting panicSetting = new PanicSetting();
            panicSetting.PanicSetttingId = willUpdateItem.PanicSetttingId;
            panicSetting.FirstPersonName = txtFirstPersonName.Text;
            panicSetting.FirstPersonNumber = txtFirstPersonNumber.Text;
            panicSetting.IsCallAlarmActive = chkIsCallAlarmActive.Checked;
            panicSetting.IsSmsAlarmActive = chkIsSmsAlarmActive.Checked;
            panicSetting.SecondPersonName = txtSecondPersonName.Text;
            panicSetting.SecondPersonNumber = txtSecondPersonNumber.Text;
            panicSetting.UserId = GlobalSettings.userId;

            panicSetting.Save();

            Toast.MakeText(this, "Panik ayarlarınız kaydedilmiştir.", ToastLength.Short).Show();

            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
    }
}