using ASP_Front.Infrastructure;
using DAL_Esports_Global.Services;
using DALBase.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ASP_Front.Models.ViewModels.Bet
{
    public class BetRegisterForm
    {
        private TournamentService _tournamentService;
        private DateTime _FakeNow;

        private List<Tournament> _tournaments;

        public List<Tournament> _displayTournaments
        {
            get => _tournaments;
        }
     
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

            _tournamentService = new TournamentService();
            _tournaments = _tournamentService.GetAll().Where(t => t.EndAt == null || t.EndAt > _FakeNow).ToList();
        }

        public bool SaveToDB()
        {
            UserService service = new UserService();
            return service.AddUserBet(UserSession.User.UserID, MatchId, BettedWinnerId);
        }

        public int GetAvailableMatches(Tournament tournament)
        {
            return _tournamentService.GetNumberOfAvailableMatches(UserSession.User.UserID, tournament.Id, _FakeNow);
        }
    }
}