using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apisJacob.Models.WS;

namespace apisJacob.Controllers
{
    public class AccessController : ApiController
    {
        [HttpGet]
        public Reply HelloWord()
        {
            Reply oR = new Reply();
            oR.result = 1;
            oR.message = "Hi World!";
            return oR;
        }
    }
}
