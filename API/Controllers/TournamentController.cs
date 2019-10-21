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
    public class TournamentController : ApiController
    {
        IHttpActionResult Get(int id)
        {
            TournamentService ts = new TournamentService();
            Tournament t = ts.Get(id);

            return Json(t);
        }
    }
}
