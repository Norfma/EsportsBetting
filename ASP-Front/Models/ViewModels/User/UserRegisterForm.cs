using ASP_Front.Infrastructure;
using DAL_Esports_Global.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Front.Models.ViewModels.User
{
    public class UserRegisterForm
    {
        private UserModel user;

        [Display(Name = "Username")]
        [Required]
        [StringLength(16, MinimumLength = 3)]
        public string Username
        {
            get => user.Username;
            set => user.Username = value;
        }

        [Required]
        [Display(Name = "Mot de passe", Description = "Votre mot de passe doit contenir au minimum 8 caractères et être composé d'une majuscule et d'un chiffre.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,12}$", ErrorMessage = "Votre mot de passe doit contenir au minimum 8 caractères et être composé d'une majuscule et d'un chiffre.")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }

        [Required]
        [Display(Description = "Confirmer le mot de passe")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,12}$", ErrorMessage = "Votre mot de passe doit contenir au minimum 8 caractères et être composé d'une majuscule et d'un chiffre.")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Pwd))]
        public string PwdCheck { get; set; }

        public UserRegisterForm()
        {
            user = new UserModel();
        }

        public UserModel SaveToDB()
        {
            UserService service = new UserService();
            user.UserId = service.Insert(new DALBase.Data.User() { Username = Username, Hashpwd = HashService.GetCrypt(Pwd), Salt = "none"});
            return user;
        }
    }
}