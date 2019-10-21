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
    public class GameController : ApiController
    {
        IHttpActionResult Get(int id)
        {
            GameService gs = new GameService();
            Game g = gs.Get(id);

            return Json(g);
        }
    }
}
