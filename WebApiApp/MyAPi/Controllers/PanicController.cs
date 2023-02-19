using MyAPi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPi.Controllers
{
    public class PanicController : ApiController
    {
        [Authorize]
        public void Get(string number, string address)
        {
            Utilities.PanicSms(number, address);
        }
    }
}
