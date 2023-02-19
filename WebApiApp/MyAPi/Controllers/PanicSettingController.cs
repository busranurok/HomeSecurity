using MyAPi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPi.Controllers
{
    public class PanicSettingController : ApiController
    {
        Logger logger = new Logger();
        [Authorize]
        public PanicSetting Post([FromBody]PanicSetting panicSetting)
        {
            try
            {
                if (panicSetting.PanicSetttingId == 0)
                {
                    panicSetting.InsertDB();
                    panicSetting.PanicSetttingId = panicSetting.GetLastId();
                    panicSetting.UpdateUser(panicSetting.UserId, panicSetting.PanicSetttingId);
                    return panicSetting;
                }
                else
                {
                    panicSetting.Update();
                    return panicSetting;
                }
            }
            catch (Exception ex)
            {
                logger.AddLog("PanicSettingController Post Hata :" + ex.Message, Logger.LogLevel.Error);
                return new PanicSetting();
            }
        }

        [Authorize]
        public PanicSetting Get(int panicSettingId)
        {
            return PanicSetting.GetObjects().FirstOrDefault(x => x.PanicSetttingId == panicSettingId);
        }

    }
}
