using ASP_Front.Infrastructure;
using DAL_Esports_Global.Services;
using DALBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Front.Models.ViewModels.Bet
{
    public class MatchForm
    {
        public List<Match> matches = new List<Match>();
        private List<DALBase.Data.Bet> bettedMatches = new List<DALBase.Data.Bet>();
        public MatchForm(int id)
        {
            MatchService matchService = new MatchService();
            UserService userService = new UserService();

            bettedMatches = userService.GetUserBets(UserSession.User.UserID).ToList();
            matches = matchService.GetAll().Where(m => m.TournamentId == id && !bettedMatches.Any(b=>b.MatchId == m.Id)).ToList();
        }
    }
}