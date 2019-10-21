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
    public class PlayerController : ApiController
    {
        IHttpActionResult Get(int id)
        {
            PlayerService ps = new PlayerService();
            Player p = ps.Get(id);

            return Json(p);
        }
    }
}
