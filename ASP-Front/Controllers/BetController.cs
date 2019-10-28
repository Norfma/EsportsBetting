using ASP_Front.Attributes;
using ASP_Front.Infrastructure;
using ASP_Front.Models.ViewModels.Bet;
using DAL_Esports_Global.Services;
using DALBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Front.Controllers
{
    public class BetController : Controller
    {
        // GET: Bet
        [LoginRequired]
        public ActionResult Index()
        {
            UserService service = new UserService();

            IEnumerable<Bet> bets = service.GetUserBets(UserSession.User.UserID);

            return View();
        }

        [LoginRequired]
        public ActionResult Register()
        {
            BetRegisterForm form = new BetRegisterForm();

            return View(form);
        }

        public ActionResult RegisterMatches(int id)
        {
            MatchForm form = new MatchForm(id);
            return PartialView(form);
        }

        public ActionResult RegisterTeams(int id)
        {
            TeamForm form = new TeamForm(id);
            return PartialView(form);
        }

    }
}