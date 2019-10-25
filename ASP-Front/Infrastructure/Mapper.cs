using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP = ASP_Front.Models;
using DC = DALBase.Data;

namespace ASP_Front.Infrastructure
{
    public static class Mapper
    {
        public static ASP.UserModel ToASP(this DC.User user)
        {
            return (user == null) ? null : new ASP.UserModel()
            {
                UserId = user.Id,
                Username = user.Username,
                PwdHash = user.Hashpwd
            };
        }
    }
}