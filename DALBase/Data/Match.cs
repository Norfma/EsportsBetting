using DALBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBase.Data
{
    /// <summary>
    /// A Match from a Tournament
    /// </summary>
    public class Match : IEntity<int>
    {
        public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int TournamentId { get; set; }
        public DateTime BeginAt { get; set; }
        public DateTime EndAt { get; set; }
        public bool Draw { get; set; }
        public bool Forfeit { get; set; }
        public string MatchType { get; set; }
        public int NumberOfGames { get; set; }
    }
}
