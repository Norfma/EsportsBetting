using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALBase.Interfaces;
namespace DALBase.Data
{
    public class Bet:IEntity<int[]>
    {
        public int[] Id { get; set; }

        public int UserId { get => Id[0]; set => Id[0] = value; }
        public int MatchId { get => Id[0]; set => Id[0] = value; }
        public int BettedWinner { get; set; }
    }
}
