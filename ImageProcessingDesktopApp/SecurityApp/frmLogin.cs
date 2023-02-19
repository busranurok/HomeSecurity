using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuvenlikDesktop.Classes;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace GuvenlikDesktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        BusinessRecognition recognition = new BusinessRecognition("D:\\", "Model", "face.xml");
        Classifier_Train train = new Classifier_Train("D:\\", "Model", "face.xml");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //RecognisePicture(null);
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre alanlarından herhangi biri boş olamaz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            User user = User.GetObjects().FirstOrDefault(x => x.Username == txtUsername.Text.Trim() && x.Password == txtPassword.Text.Trim());
            if (user!=null)
            {
                GlobalSetting.UserId = user.UserId;
                GlobalSetting.Username = user.Username;
                GlobalSetting.UserAlarmSettingId = user.AlarmSettingId;
                GlobalSetting.IsAdmin = user.IsAdmin;

                if (!user.IsAdmin)
                    GlobalSetting.CustomerId = user.CustomerId;

                frmMenu frm = new frmMenu();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girmiş olduğunuz bilgilere ait kullanıcı bulunamadı","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void RecognisePicture(MemoryStream memoryStream)
        {
            Image<Gray, byte> img = new Image<Gray, byte>(new Bitmap("C:\\Users\\CurrentUser\\Desktop\\ss.bmp"));
            HaarCascade haaryuz = new HaarCascade("haarcascade_frontalface_alt2.xml");
            MCvAvgComp[][] Yuzler = img.DetectHaarCascade(haaryuz, 1.2, 5, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));

            foreach (MCvAvgComp item in Yuzler[0])
            {
                var yuz = img.Copy(item.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                string name = train.Recognise(yuz);
                if (string.IsNullOrEmpty(name) || name == "Tanımsız")
                {
                    AlarmSetting alarm = AlarmSetting.GetObjects().FirstOrDefault(x => x.AlarmSettingId == GlobalSetting.UserAlarmSettingId);
                    if (alarm.IsActive)
                    {
                        if (alarm.IsCallAlarmActive)
                        {
                            if (!string.IsNullOrEmpty(alarm.FirstPersonNumber))
                            {
                                if (alarm.SecondPersonNumber.Length == 10)
                                    alarm.SecondPersonNumber = "+90" + alarm.SecondPersonNumber;
                                else if (alarm.SecondPersonNumber.Length == 11)
                                    alarm.SecondPersonNumber = "+9" + alarm.SecondPersonNumber;
                                AlertRequest request = new AlertRequest();
                                request.AlarmNumber = alarm.SecondPersonNumber;
                                request.AlarmParameter = string.Empty;
                                request.AlarmType = "CallAlarm";
                                request.IsAlerted = false;
                                request.Insert();
                            }

                            if (!string.IsNullOrEmpty(alarm.SecondPersonNumber))
                            {
                                if (alarm.SecondPersonNumber.Length == 10)
                                    alarm.SecondPersonNumber = "+90" + alarm.SecondPersonNumber;
                                else if (alarm.SecondPersonNumber.Length == 11)
                                    alarm.SecondPersonNumber = "+9" + alarm.SecondPersonNumber;
                                AlertRequest request = new AlertRequest();
                                request.AlarmNumber = alarm.SecondPersonNumber;
                                request.AlarmParameter = string.Empty;
                                request.AlarmType = "CallAlarm";
                                request.IsAlerted = false;
                                request.Insert();
                            }

                        }
                        else if (alarm.IsPoliceAlarmActive)
                        {
                            if (alarm.SecondPersonNumber.Length == 10)
                                alarm.SecondPersonNumber = "+90" + alarm.SecondPersonNumber;
                            else if (alarm.SecondPersonNumber.Length == 11)
                                alarm.SecondPersonNumber = "+9" + alarm.SecondPersonNumber;
                            AlertRequest request = new AlertRequest();
                            request.AlarmNumber = "911";
                            request.AlarmParameter = string.Empty;
                            request.AlarmType = "CallAlarm";
                            request.IsAlerted = false;
                            request.Insert();
                        }
                        else if (alarm.IsSmsAlarmActive)
                        {
                            if (alarm.SecondPersonNumber.Length == 10)
                                alarm.SecondPersonNumber = "+90" + alarm.SecondPersonNumber;
                            else if (alarm.SecondPersonNumber.Length == 11)
                                alarm.SecondPersonNumber = "+9" + alarm.SecondPersonNumber;
                            AlertRequest request = new AlertRequest();
                            request.AlarmNumber = alarm.SecondPersonNumber;
                            request.AlarmParameter = string.Empty;
                            request.AlarmType = "SmsAlarm";
                            request.IsAlerted = false;
                            request.Insert();
                        }
                    }
                }
            }
        }
    }
}
