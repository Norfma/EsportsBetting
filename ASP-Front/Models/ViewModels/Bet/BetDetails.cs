using DAL_Esports_Global.Services;
using DALBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Front.Models.ViewModels.Bet
{
    public class BetDetails
    {
        public string Team1Name { get; set; }
        public int Team1Score { get; set; }

        public string Team2Name { get; set; }
        public int Team2Score { get; set; }

        public bool isWon { get; private set; }

        public BetDetails(DALBase.Data.Bet bet)
        {
            MatchService matchService = new MatchService();
            Match match = matchService.Get(bet.MatchId);

            Team1Name = match.Team1Name;
            Team2Name = match.Team2Name;

            IEnumerable<Game> games = matchService.GetGamesFromMatch(bet.MatchId);
            foreach(Game game in games)
            {
                if (game.WinnerId == match.Team1Id)
                {
                    Team1Score++;
                }
                else if (game.WinnerId == match.Team2Id)
                {
                    Team2Score++;
                }
            }

            if (bet.BettedWinner == match.Team1Id && Team1Score > Team2Score)
            {
                isWon = true;
            }
            else if (bet.BettedWinner == match.Team2Id && Team2Score > Team1Score)
            {
                isWon = true;
            }
            else
            {
                isWon = false;
            }
        }
    }
}