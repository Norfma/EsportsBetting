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
    public static class UpdateTournaments
    {
        public static void Update()
        {
            HttpClient client = new HttpClient();
            string Url = PandaScoreUtils.PandaBaseAddress + $"tournaments?token={PandaScoreUtils.Token}&{PandaScoreUtils.MaxPerPage}";
            List<TournamentApi> tournaments = new List<TournamentApi>();

            HttpResponseMessage msg = client.GetAsync(Url).Result;
            tournaments.AddRange(JsonConvert.DeserializeObject<List<TournamentApi>>(msg.Content.ReadAsStringAsync().Result));

            TournamentService tournamentService = new TournamentService();
            TeamTournamentService teamTournamentService = new TeamTournamentService();

            foreach (TournamentApi t in tournaments)
            {
                Tournament tournament = new Tournament()
                {
                    BeginAt = t.BeginAt,
                    EndAt = t.EndAt,
                    Id = t.Id,
                    ImageURL = t.League.ImageURL,
                    LeagueName = t.League.Name,
                    Name = t.Name,
                    Prizepool = t.Prizepool,
                    SeriesFullName = t.Serie.FullName
                };

                tournamentService.Update(tournament);

                foreach (TeamApi team in t.Teams)
                {
                    TeamTournamentRegister TTR = new TeamTournamentRegister()
                    {
                        TeamId = team.Id,
                        TournamentId = t.Id
                    };
                    teamTournamentService.Update(TTR);
                }
            }
        }
    }
}
