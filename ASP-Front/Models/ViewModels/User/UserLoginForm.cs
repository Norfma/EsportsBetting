using ASP_Front.Infrastructure;
using DAL_Esports_Global.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Front.Models.ViewModels.User
{
    public class UserLoginForm
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(16, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool LoginCheck()
        {
            UserService service = new UserService();
            List<UserModel> users = service.GetByUsername(Username).Select(u => u.ToASP()).ToList();

            if (users.Count > 0)
            {
                foreach(UserModel u in users)
                {
                    if (u.PwdHash == HashService.GetCrypt(Password))
                    {
                        UserSession.User = new SessionUser(u.UserId, u.Username);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}