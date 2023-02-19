using MyAPi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPi.Controllers
{
    public class DeviceController : ApiController
    {
        [HttpPost]
        public void Post([FromBody]MobileRegistration token)
        {
            int userId= Classes.User.GetObjects().FirstOrDefault(x => x.Username == token.Username).UserId;
            Device device = Device.GetObjects().FirstOrDefault(x => x.UserId == userId);

            if (device!=null)
            {
                device.DeviceToken = token.Token;
                device.LastLoginDate = DateTime.Now;
                device.DeviceName = string.Empty;
                device.Update();
            }
            else
            {
                Device willInsertDevice = new Device();
                willInsertDevice.UserId = userId;
                willInsertDevice.DeviceToken = token.Token;
                willInsertDevice.LastLoginDate = DateTime.Now;
                willInsertDevice.DeviceName = string.Empty;
                willInsertDevice.InsertDB();
            }
        }
    }
}
