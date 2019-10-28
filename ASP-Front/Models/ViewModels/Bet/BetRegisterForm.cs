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
        private TournamentService _tournamentService;
        //private MatchService _matchService;
        //private TeamService _teamService;
        private DateTime _FakeNow;

        private List<Tournament> _tournaments;
        //private List<Match> _matches;

        public List<Tournament> _displayTournaments
        {
            get => _tournaments;
        }

        //public List<Match> _displayMatch
        //{
        //    get => _matches.Where(m => m.TournamentId == TournamentId).ToList();
        //}

        //public List<Team> _displayTeam
        //{
        //    get
        //    {
        //        List<Team> list = new List<Team>();
        //        Match _match = _matches.Where(m => m.Id == MatchId).FirstOrDefault();
        //        if (_match != null)
        //        {
        //            list.Add(_teamService.Get(_match.Team1Id));
        //            list.Add(_teamService.Get(_match.Team2Id));
        //        }
        //        return list;
        //    }
        //}

     
        public int BettedWinnerId
        {
            get; set;
        }
        
        public int TournamentId
        {
            get; set;
        }
        
        public int MatchId
        {
            get;
            set;
        }

        public BetRegisterForm()
        {
            _FakeNow = new DateTime(2019, 10, 10);

            //_matchService = new MatchService();
            //_matches = _matchService.GetAll().Where(m => m.EndAt == null || m.EndAt > _FakeNow).ToList();

            _tournamentService = new TournamentService();
            _tournaments = _tournamentService.GetAll().Where(t => t.EndAt == null || t.EndAt > _FakeNow).ToList();

            //_teamService = new TeamService();

        }

        public bool SaveToDB()
        {
            UserService service = new UserService();
            return service.AddUserBet(UserSession.User.UserID, MatchId, BettedWinnerId);
        }
    }
}