using DALBase.Data;
using Newtonsoft.Json;
using PandascoreDAL.Service;
using PandascoreUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UpdateTeamsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex(@"<(\S*)>");
            HttpClient client = new HttpClient();
            string Url = PandaScoreUtils.PandaBaseAddress + $"teams?token={PandaScoreUtils.Token}&{PandaScoreUtils.MaxPerPage}";
            List<TeamApi> teams = new List<TeamApi>();

            do
            {
                HttpResponseMessage msg = client.GetAsync(Url).Result;
                teams.AddRange(JsonConvert.DeserializeObject<List<TeamApi>>(msg.Content.ReadAsStringAsync().Result));

                IEnumerable<string> links;
                msg.Headers.TryGetValues("Link", out links);

                Url = links.First().Split(',').FirstOrDefault(s => s.Contains("rel=\"next\""));
                if (Url != null)
                {
                    Url = reg.Match(Url).Groups[1].Value;
                }
            } while (Url != null);

            TeamService teamService = new TeamService();
            PlayerService playerService = new PlayerService();

            foreach (TeamApi t in teams)
            {
                Team team = new Team()
                {
                    Id = t.Id,
                    ImageURL = t.ImageURL,
                    Name = t.Name,
                    Acronym = t.Acronym
                };

                if (teamService.Update(team))
                {
                    foreach (PlayerApi p in t.Players)
                    {
                        Player player = new Player()
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            Name = p.Name,
                            TeamId = t.Id
                        };
                        playerService.Update(player);
                    }
                }
            }
        }
    }

    class TeamApi
    {
        public string Acronym { get; set; }
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public List<PlayerApi> Players { get; set; }
    }

    public class PlayerApi
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
    }
}

