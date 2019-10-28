using DAL_Esports_Global.Services;
using DALBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Front.Models.ViewModels.Bet
{
    public class TeamForm
    {
        public List<Team> teams = new List<Team>();
        public TeamForm(int id)
        {
            TeamService teamService = new TeamService();
            MatchService matchService = new MatchService();

            Match match = matchService.Get(id);

            teams.Add(teamService.Get(match.Team1Id));
            teams.Add(teamService.Get(match.Team2Id));
        }
    }
}