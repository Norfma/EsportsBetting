using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDatabaseFromAPI.DataAPI
{
    class MatchApi
    {
        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }
        public bool Draw { get; set; }
        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }
        public bool Forfeit { get; set; }
        public GameApi[] Games { get; set; }
        public int Id { get; set; }
        [JsonProperty("match_type")]
        public string MatchType { get; set; }
        [JsonProperty("number_of_games")]
        public int? NumberOfGames { get; set; }
        public Opponents[] Opponents { get; set; }
        [JsonProperty("tournament_id")]
        public int TournamentId { get; set; }
    }

    class Opponents
    {
        public Opponent opponent { get; set; }
    }

    class Opponent
    {
        public int Id { get; set; }
    }
}
