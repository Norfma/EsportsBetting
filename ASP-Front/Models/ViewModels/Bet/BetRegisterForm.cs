using ASP_Front.Infrastructure;
using DAL_Esports_Global.Services;
using DALBase.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Front.Models.ViewModels.Bet
{
    public class BetRegisterForm
    {

        private List<Match> _matches;

        [HiddenInput(DisplayValue = false)]
        public int MatchId
        {
            get => student.SectionId;
            set => student.SectionId = value;
        }

        public BetRegisterForm()
        {
        }

        public UserModel SaveToDB()
        {
            UserService service = new UserService();
            service.AddUserBet(UserSession.User.UserID, matchId, winnerId);
            return user;
        }
    }
}