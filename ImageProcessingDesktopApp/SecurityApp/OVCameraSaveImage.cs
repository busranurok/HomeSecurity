using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using SKYPE4COMLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuvenlikDesktop.Classes;
using System.Reflection;
using System.Speech.Synthesis;
using WindowsFormsApp56.Classes;

namespace GuvenlikDesktop
{
    public partial class OVCameraSaveImage : Form
    {
        static string directory = "C:\\";
        static string folder = "Model";
        static string xml = "face.xml";
        SerialPort _mySerialPort;
        private Bitmap _bitmap;
        private Size _bitmapSize = new Size(240, 320);
        System.Timers.Timer tmrAlert;
        private SpeechSynthesizer Speak = new SpeechSynthesizer();
        SKYPE4COMLib.Skype skype = new Skype();

        BusinessRecognition recognition = new BusinessRecognition(directory, folder, xml);
        Classifier_Train train = new Classifier_Train(directory, folder, xml);

        public Bitmap MyBitmap
        {
            get
            {
                if (this._bitmap == null)
                    this._bitmap = new Bitmap(this._bitmapSize.Width, this._bitmapSize.Height);
                return this._bitmap;
            }
        }
        public OVCameraSaveImage()
        {
            InitializeComponent();
            tmrAlert = new System.Timers.Timer();
            tmrAlert.Interval = 10000;
            tmrAlert.Enabled = true;
            tmrAlert.Elapsed += TmrAlert_Elapsed;
            tmrAlert.Start();

            if (GlobalSetting.CustomerId != 0)
            {
                Customer customer = Customer.GetObjectById(Convert.ToInt32(GlobalSetting.CustomerId));
                directory = customer.ModelDirectoryName;
                folder = customer.ModelFolderName;
                xml = customer.ModelXmlName;
            }

            skype.Timeout = 20 * 1000;
            skype.CallStatus += Skype_CallStatus;
        }

        private void TmrAlert_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<AlertRequest> nonCompletedRequests = AlertRequest.GetNonCompletedAlarms();

            if (nonCompletedRequests.Count>0)
            {
                foreach (var item in nonCompletedRequests)
                {
                    if (!skype.Client.IsRunning)
                    {
                        skype.Client.Start(true, true);
                    }

                    if (item.AlarmType== "CallAlarm")
                    {
                        try
                        {
                            if (skype.ActiveCalls.Count == 0)
                            {
                                Call call = skype.PlaceCall(item.AlarmNumber);
                                AlertRequest.Update(item.AlarmRequestId);
                            }
                            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                            string filepath = System.IO.Path.Combine(path, "tmp.wav");
                            //Speak.SetOutputToWaveFile(filepath);
                            //Speak.Speak("Hello world");
                            //Speak.SetOutputToDefaultAudioDevice();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else if (item.AlarmType== "SmsAlarm")
                    {
                        try
                        {
                            var smsType = SKYPE4COMLib.TSmsMessageType.smsMessageTypeOutgoing;
                            var message = skype.CreateSms(smsType, item.AlarmNumber);
                            message.Body = "Acil Durum:Evimde birileri var";
                            message.Send();
                            AlertRequest.Update(item.AlarmRequestId);
                        }
                        catch (Exception ex)
                        {
                        }
                       
                    }
                    else if (item.AlarmType== "PanicSms")
                    {
                        try
                        {
                            var smsType = SKYPE4COMLib.TSmsMessageType.smsMessageTypeOutgoing;
                            var message = skype.CreateSms(smsType, item.AlarmNumber);
                            message.Body = "Acil Durum! Güvende olmadığımı hissediyorum.Konum:" + item.AlarmParameter;
                            message.Send();
                            AlertRequest.Update(item.AlarmRequestId);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }

        private void Skype_CallStatus(Call pCall, TCallStatus Status)
        {
            if (Status == TCallStatus.clsInProgress)
            {
                axWindowsMediaPlayer1.URL = @"C:\Users\CurrentUser\Desktop\alert.wav";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
               
        }

        private void OVCameraSaveImage_Load(object sender, EventArgs e)
        {
            CheckSerialPorts();
        }

        private bool CheckSerialPorts()
        {
            string[] portNames = SerialPort.GetPortNames();
            if ((uint)portNames.Length <= 0U)
                return false;

            this._mySerialPort = new SerialPort(portNames[0])
            {
                BaudRate = 1000000,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None,
                ReadTimeout = 10000
            };
            this._mySerialPort.DataReceived += new SerialDataReceivedEventHandler(this.DataReceivedHandler);
            this._mySerialPort.Open();
            return true;
        }

        //serial porttan veri gelince otomatik olarak girer
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort serialPort = (SerialPort)sender;
                byte[] buffer = new byte[5];
                if (!serialPort.IsOpen)
                    return;
                if (serialPort.Read(buffer, 0, buffer.Length) > 4 && (int)buffer[0] == 42 && ((int)buffer[1] == 82 && (int)buffer[2] == 68) && (int)buffer[3] == 89 && (int)buffer[4] == 42)
                {
                    System.Windows.Forms.Application.DoEvents();
                    for (int x = 0; x < 240; ++x)
                    {
                        for (int y = 319; y >= 0; --y)
                        {
                            if (!serialPort.IsOpen)
                                return;
                            int num = serialPort.ReadByte();
                            int blue = num;
                            int green = num;
                            int red = num;
                            this.MyBitmap.SetPixel(x, y, Color.FromArgb(1, red, green, blue));
                        }
                    }
                    MemoryStream memoryStream = new MemoryStream();
                    
                    try
                    {
                        this.MyBitmap.Save((Stream)memoryStream, ImageFormat.Bmp);
                        this.pictureBox1.Invoke((Action)(() => 
                        this.pictureBox1.Image = Image.FromStream((Stream)memoryStream)));
                        RecognisePicture(memoryStream);
                    }
                    finally
                    {
                        if (memoryStream != null)
                            memoryStream.Dispose();
                    }
                    Thread.Sleep(500);
                    System.Windows.Forms.Application.DoEvents();
                    //this.CloseSerialPort();
                }
                else
                    serialPort.ReadExisting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", (object)ex.Message));
            }
        }

        //gelen resmi model ile kıyasla
        private void RecognisePicture(MemoryStream memoryStream)
        {
            Image<Gray, byte> img = new Image<Gray, byte>(new Bitmap(Image.FromStream((Stream)memoryStream)));
            HaarCascade haaryuz = new HaarCascade("haarcascade_frontalface_alt2.xml");
            MCvAvgComp[][] Yuzler = img.DetectHaarCascade(haaryuz, 1.2, 5, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(15, 15));

            foreach (MCvAvgComp item in Yuzler[0])
            {
                List<Classes.User> customerUsers = Classes.User.GetObjects().Where(x=> x.CustomerId==GlobalSetting.CustomerId).ToList(); 
                var yuz = img.Copy(item.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                string name = train.Recognise(yuz);
                if (string.IsNullOrEmpty(name) || name== "Tanımsız" ||  customerUsers.FirstOrDefault(x=> x.Username==name)==null )
                {
                    AlarmSetting alarm = AlarmSetting.GetObjects().FirstOrDefault(x => x.AlarmSettingId == GlobalSetting.UserAlarmSettingId);
                    if (alarm.IsActive)
                    {
                        if (alarm.IsCallAlarmActive)
                        {
                            if (!string.IsNullOrEmpty(alarm.FirstPersonNumber))
                            {
                                if (alarm.FirstPersonNumber.Length == 10)
                                    alarm.FirstPersonNumber = "+90" + alarm.FirstPersonNumber;
                                else if (alarm.FirstPersonNumber.Length == 11)
                                    alarm.FirstPersonNumber = "+9" + alarm.FirstPersonNumber;
                                AlertRequest request = new AlertRequest();
                                request.AlarmNumber = alarm.FirstPersonNumber;
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

        private void CloseSerialPort()
        {
            if (this._mySerialPort == null || !this._mySerialPort.IsOpen)
                return;
            this._mySerialPort.Close();
        }

        private void OVCameraSaveImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSerialPort();
        }
    }
}
