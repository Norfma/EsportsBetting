using DAL_Esports_Global.Services;
using DALBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MatchController : ApiController
    {
        IHttpActionResult Get(int id)
        {
            MatchService ms = new MatchService();
            Match m = ms.Get(id);

            return Json(m);
        }
    }
}
