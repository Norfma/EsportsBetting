using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Front.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PwdHash { get; set; }
    }
}