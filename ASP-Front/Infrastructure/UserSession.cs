using ASP_Front.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Front.Infrastructure
{
    public static class UserSession
    {
        public static SessionUser User
        {
            get => (SessionUser)HttpContext.Current.Session["User"];
            set => HttpContext.Current.Session["User"] = value;
        }
    }
}