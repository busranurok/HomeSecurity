using MyAPi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPi.Controllers
{
    public class AlarmSettingController : ApiController
    {
        [Authorize]
        public AlarmSetting Post([FromBody]AlarmSetting alarmSetting)
        {
            if (alarmSetting.AlarmSettingId==0)
            {
                alarmSetting.InsertDB();
                alarmSetting.AlarmSettingId = alarmSetting.GetLastId();
                alarmSetting.UpdateUser(alarmSetting.UserId, alarmSetting.AlarmSettingId);
                return alarmSetting;
            }
            else
            {
                alarmSetting.Update();
                return alarmSetting;
            }
        }

        [Authorize]
        public AlarmSetting Get(int alarmSettingId)
        {
            return AlarmSetting.GetObjects().FirstOrDefault(x => x.AlarmSettingId == alarmSettingId);
        }

        public void Get(string alarmMessage)
        {

        }
    }
}
