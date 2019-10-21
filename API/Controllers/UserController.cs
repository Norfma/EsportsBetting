using DAL_Esports_Global.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            UserService userService = new UserService();
            DALBase.Data.User user = userService.Get(id);

            return Json(user);
        }

        [AcceptVerbs("POST")]
        public IHttpActionResult Post(DALBase.Data.User user)
        {
            //TODO Model Applicatif

            UserService userService = new UserService();

            //TODO Add procedure to check mail before insert (for louison)
            try
            {
                user.Id = userService.Insert(user);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    error = "Erreur lors de l'insertion."
                });
            }
        }
    }
}
