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
    public static class UpdateMatchesAndGames
    {
        public static void Update()
        {
            HttpClient client = new HttpClient();
            string Url = PandaScoreUtils.PandaBaseAddress + $"matches?token={PandaScoreUtils.Token}&{PandaScoreUtils.MaxPerPage}";
            List<MatchApi> matches = new List<MatchApi>();

            do
            {
                HttpResponseMessage msg = client.GetAsync(Url).Result;
                matches.AddRange(JsonConvert.DeserializeObject<List<MatchApi>>(msg.Content.ReadAsStringAsync().Result));

                Url = msg.Headers.GetNextURL();
            } while (Url != null);

            MatchService matchService = new MatchService();
            GameService gameService = new GameService();

            foreach (MatchApi m in matches)
            {
                DALBase.Data.Match match;
                if (m.Opponents.Length >= 2)
                { 
                    match = new DALBase.Data.Match()
                    {
                        BeginAt = m.BeginAt,
                        Draw = m.Draw,
                        EndAt = m.EndAt,
                        Forfeit = m.Forfeit,
                        Id = m.Id,
                        MatchType = m.MatchType,
                        NumberOfGames = m.NumberOfGames,
                        Team1Id = m.Opponents[0].opponent.Id,
                        Team2Id = m.Opponents[1].opponent.Id,
                        TournamentId = m.TournamentId
                    };
                

                    if (matchService.Update(match))
                    {
                        foreach (GameApi g in m.Games)
                        {
                            Game game = new Game()
                            {
                                Id = g.Id,
                                Forfeit = g.Forfeit,
                                BeginAt = g.BeginAt,
                                EndAt = g.EndAt,
                                Finished = g.Finished,
                                Length = g.Length,
                                Position = g.Position,
                                Status = g.Status,
                                WinnerId = g.Winner.Id,
                                MatchId = m.Id
                            };
                            gameService.Update(game);
                        }
                    }
                }
            }
        }
    }
}
