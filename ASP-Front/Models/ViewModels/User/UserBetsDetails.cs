using ASP_Front.Models.ViewModels.Bet;
using DAL_Esports_Global.Services;
using DALBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Front.Models.ViewModels.User
{
    public class UserBetsDetails
    {
        public string Username { get; set; }
        public List<DALBase.Data.Bet> bets;
        public List<BetDetails> betDetails;
        public int UserScore { get; set; }

        public UserBetsDetails(string username)
        {
            Username = username;
            UserService userService = new UserService();
            DALBase.Data.User user = userService.GetByUsername(username).FirstOrDefault();

            bets = userService.GetUserBets(user.Id).ToList();

            betDetails = new List<BetDetails>();
            foreach(var bet in bets)
            {
                BetDetails details = new BetDetails(bet);
                betDetails.Add(details);
                if (details.isWon) UserScore++;
            }
        }
    }
}