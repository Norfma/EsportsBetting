using Newtonsoft.Json;
using PandascoreUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMatchesTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = PandaScoreUtils.PandaBaseAddress;

            HttpResponseMessage msg = client.GetAsync($"players?token={PandaScoreUtils.Token}").Result;
            List<MatchApi> o = JsonConvert.DeserializeObject<List<MatchApi>>(msg.Content.ReadAsStringAsync().Result);

            Console.ReadLine();
        }
    }

    class PlayerContainer
    {
        List<MatchApi> playerApi { get; set; }
    }

    class MatchApi
    {
        public DateTime BeginAt { get; set; }
        public bool Draw { get; set; }
        public DateTime EndAt { get; set; }
        public bool Forfeit { get; set; }
        public GameApi[] Games { get; set; }
        public int Id { get; set; }
        public string MatchType { get; set; }
        [JsonProperty("number_of_games")]
        public int NumberOfGames { get; set; }
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
    class GameApi
    {
        [JsonProperty("begin_at")]
        public DateTime BeginAt { get; set; }
        [JsonProperty("end_at")]
        public DateTime EndAt { get; set; }

        public bool Finished { get; set; }
        public bool Forfeit { get; set; }
        public int Id { get; set; }
        public int Length { get; set; }
        public int MatchId { get; set; }
        public int Position { get; set; }
        public string Status { get; set; }
        public Winner Winner { get; set; }
    }

    class Winner
    {
        public int Id { get; set; }
    }
}
