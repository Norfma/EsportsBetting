using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALBase.Interfaces;
namespace DALBase.Data
{
    public class Bet
    {
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public int BettedWinner { get; set; }
    }
}
