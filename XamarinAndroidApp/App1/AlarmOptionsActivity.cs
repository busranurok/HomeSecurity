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
    [Activity(Label = "AlarmOptionsActivity")]
    public class AlarmOptionsActivity : Activity
    {
        EditText txtFirstPersonName;
        EditText txtFirstPersonNumber;
        EditText txtSecondPersonName;
        EditText txtSecondPersonNumber;
        EditText txtDistance;
        CheckBox chkAlarmWithCall;
        CheckBox chkAlarmWithSms;
        CheckBox chkAlarmWithPolice;
        CheckBox chkIsActive;
        AlarmSetting willUpdateItem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.alarm_options);

            willUpdateItem = new AlarmSetting();
            willUpdateItem.AlarmSettingId = GlobalSettings.alarmSettingId;
            
            Button btnSave = FindViewById<Button>(Resource.Id.btnSaveAlarmOptions);
            btnSave.Click += BtnSave_Click;

            txtDistance = FindViewById<EditText>(Resource.Id.txtDistanceAlarmOptions);
            txtFirstPersonName = FindViewById<EditText>(Resource.Id.txtFirsPersonNameAlarmOptions);
            txtFirstPersonNumber = FindViewById<EditText>(Resource.Id.txtFirstPersonNumberAlarmOptions);
            txtSecondPersonName = FindViewById<EditText>(Resource.Id.txtSecondPersonNameAlarmOptions);
            txtSecondPersonNumber = FindViewById<EditText>(Resource.Id.txtSecondPersonNumberAlarmOptions);
            chkAlarmWithCall = FindViewById<CheckBox>(Resource.Id.chkAlarmWithCallAlarmOptions);
            chkAlarmWithSms = FindViewById<CheckBox>(Resource.Id.chkAlarmWithSmsAlarmOptions);
            chkAlarmWithPolice = FindViewById<CheckBox>(Resource.Id.chkAlarmWithPoliceAlarmOptions);
            chkIsActive = FindViewById<CheckBox>(Resource.Id.chkIsActiveAlarmOptions);

            // Create your application here
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            AlarmSetting item = new AlarmSetting();
            item.AlarmSettingId = willUpdateItem.AlarmSettingId;
            item.DistanceValue =Convert.ToDouble(txtDistance.Text);
            GlobalSettings.distanceValue = item.DistanceValue;
            item.FirstPersonName = txtFirstPersonName.Text;
            item.FirstPersonNumber = txtFirstPersonNumber.Text;
            item.SecondPersonName = txtSecondPersonName.Text;
            item.SecondPersonNumber = txtSecondPersonNumber.Text;
            item.IsActive = chkIsActive.Checked;
            item.IsActiveDistanceAlarm = string.IsNullOrEmpty(txtDistance.Text) ? false : true;
            item.IsCallAlarmActive = chkAlarmWithCall.Checked;
            item.IsPoliceAlarmActive = chkAlarmWithPolice.Checked;
            item.IsSmsAlarmActive = chkAlarmWithSms.Checked;

            item.Save();

            Toast.MakeText(this, "Alarm ayarlarınız kaydedilmiştir.", ToastLength.Short).Show();

            Intent intent = new Intent(this, typeof(MenuActivity));
            StartActivity(intent);
        }
    }
}