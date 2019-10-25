﻿using ASP_Front.Attributes;
using ASP_Front.Infrastructure;
using ASP_Front.Models;
using ASP_Front.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Front.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Index dans le controller User";
            return View();
        }

        // GET: Student
        [LoggedOffOnly]
        public ActionResult Register()
        {
            UserRegisterForm form = new UserRegisterForm();
            return View(form);
        }

        [HttpPost]
        [LoggedOffOnly]
        public ActionResult Register(UserRegisterForm form)
        {
            if (ModelState.IsValid)
            {
                UserModel savedUser = form.SaveToDB();
                UserSession.User = new SessionUser(savedUser.UserId, savedUser.Username);

                return RedirectToAction("Details", "User", new { username = savedUser.Username });
            }
            else
                return View(form);
        }

        [LoginRequired]
        public ActionResult Details(string username)
        {
            return View();
        }

        [LoggedOffOnly]
        public ActionResult Login()
        {
            UserLoginForm form = new UserLoginForm();
            return View(form);
        }

        [HttpPost]
        [LoggedOffOnly]
        public ActionResult Login(UserLoginForm form)
        {
            if (ModelState.IsValid)
            {
                if (form.LoginCheck())
                {
                    return RedirectToAction("Details", "User", new { username = form.Username});
                }
            }
            return View(form);
        }

        [LoginRequired]
        public ActionResult LogOut()
        {
            HttpContext.Session.Abandon();
            return RedirectToAction("Login", "User");
        }
    }
}