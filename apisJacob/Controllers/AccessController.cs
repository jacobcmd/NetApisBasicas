using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apisJacob.Models.WS;
using apisJacob.Models;

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

        [HttpPost]
        public Reply Login([fromBody] LoginViewModel model)
        {
            Reply oR = new Reply();
            oR.result = 0;
            try
            {
                using (apisEntities db = new apisEntities())
                {
                    var lst = db.user.Where(d => d.email == model.email && d.password == model.password && d.idStatus == 1);

                    if (lst.Count() > 0)
                    {
                        oR.result = 1;
                        oR.data = Guid.NewGuid().ToString();

                        user oUser = lst.First();
                        oUser.token = (string)oR.data;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        oR.message = "Datos errones";
                    }
                }
            }
            catch(Exception ex)
            {
                
                oR.message = "ocurrio un error";
            }
            return oR;
        }
    }
}
