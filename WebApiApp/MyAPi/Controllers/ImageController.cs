using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPi.Controllers
{
    public class ImageController : ApiController
    {
        Logger logger = new Logger();
        public void Post(string username)
        {
            logger.AddLog("Post Username :" + username, Logger.LogLevel.Info);
        }

        public string Get(string username)
        {
            logger.AddLog("Get Username :"+username, Logger.LogLevel.Info);
            return username;
        }
    }
}
