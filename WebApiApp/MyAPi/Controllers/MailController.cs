using MyAPi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPi.Controllers
{
    public class MailController : ApiController
    {
        [Authorize]
        public MailInformation Get()
        {
            return MailInformation.GetObjects().FirstOrDefault();
        }
    }
}
