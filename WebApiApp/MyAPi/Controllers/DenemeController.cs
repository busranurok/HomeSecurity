using MyAPi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPi.Controllers
{
    public class DenemeController : ApiController
    {
        public void Get()
        {
            Utilities.SmsAlarm("5555555555");
            //    if (alertType=="Call")
            //    {
            //        Utilities.CallAlarm(number);
            //    }
            //    else if (alertType=="Sms")
            //    {
            //        Utilities.SmsAlarm(number);
            //    }
            //    else if (alertType=="Police")
            //    {
            //        Utilities.CallAlarm("911");
            //    }
        }


    }
}
