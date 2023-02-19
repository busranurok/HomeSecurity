using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPi.Controllers
{
    public class UserController : ApiController
    {
        [Authorize]
        public Classes.User Get(string username, string password)
        {
            return Classes.User.GetObjects().FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        [Authorize]
        public List<Classes.User> Get()
        {
            return Classes.User.GetObjects();
        }
    }
}
