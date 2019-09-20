using DALBase.Data;
using MyTools;
using Newtonsoft.Json;
using PandascoreDAL.Service;
using PandascoreUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UpdateDatabaseFromAPI.DataAPI;

namespace UpdateDatabaseFromAPI
{
    public static class UpdateTeamsAndPlayers
    {
        public static void Update()
        {
            HttpClient client = new HttpClient();
            string Url = PandaScoreUtils.PandaBaseAddress + $"teams?token={PandaScoreUtils.Token}&{PandaScoreUtils.MaxPerPage}";
            List<TeamApi> teams = new List<TeamApi>();

            do
            {
                HttpResponseMessage msg = client.GetAsync(Url).Result;
                teams.AddRange(JsonConvert.DeserializeObject<List<TeamApi>>(msg.Content.ReadAsStringAsync().Result));

                Url = msg.Headers.GetNextURL();
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
}
