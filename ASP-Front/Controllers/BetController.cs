﻿using ASP_Front.Attributes;
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
            return RedirectToAction("Details", "User", new { id = UserSession.User.UserID });
        }

        [LoginRequired]
        public ActionResult Register()
        {
            BetRegisterForm form = new BetRegisterForm();

            return View(form);
        }

        [LoginRequired]
        public ActionResult RegisterMatches(int id)
        {
            MatchForm form = new MatchForm(id);
            return PartialView(form);
        }

        [LoginRequired]
        public ActionResult RegisterTeams(int id)
        {
            TeamForm form = new TeamForm(id);
            return PartialView(form);
        }

        [LoginRequired]
        [HttpPost]
        public ActionResult Register(BetRegisterForm form)
        {
            if (ModelState.IsValid && form.SaveToDB())
            {
                return RedirectToAction("Details", "User", new { username = UserSession.User.UserName });
            }
            else
                return View(form);
        }

    }
}