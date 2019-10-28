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

        public MatchForm(int id)
        {
            MatchService matchService = new MatchService();

            matches = matchService.GetAll().Where(m => m.TournamentId == id).ToList();
        }
    }
}