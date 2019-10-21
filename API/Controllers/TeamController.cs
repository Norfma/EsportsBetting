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
    public class TeamController : ApiController
    {
        IHttpActionResult Get(int id)
        {
            TeamService ts = new TeamService();
            Team t = ts.Get(id);

            return Json(t);
        }
    }
}
