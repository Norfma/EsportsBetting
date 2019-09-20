using DALBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBase.Data
{
    /// <summary>
    /// One of the games of a match
    /// </summary>
    public class Game : IEntity<int>
    {
        public int Id { get; set; }
        public int? MatchId { get; set; }
        public int? WinnerId { get; set; }
        public DateTime? BeginAt { get; set; }
        public DateTime? EndAt { get; set; }
        public bool Forfeit { get; set; }
        public bool Finished { get; set; }
        public int? Length { get; set; }
        public int Position { get; set; }
        public string Status { get; set; }
    }
}
