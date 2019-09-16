using DALBase.Data;
using DALBase.Interfaces;
using DBToolbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandascoreDAL.Service
{
    class MatchService : IUpdateService<Match>
    {
        public bool Update(Match entity)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("InsertPlayer", true);

            cmd.AddParameter("@Id", entity.Id);
            cmd.AddParameter("@Team1Id", entity.Team1Id);
            cmd.AddParameter("@Team2Id", entity.Team2Id);
            cmd.AddParameter("@TournamentId", entity.TournamentId);
            cmd.AddParameter("@BeginAt", entity.BeginAt);
            cmd.AddParameter("@EndAt", entity.EndAt);
            cmd.AddParameter("@Draw", entity.Draw);
            cmd.AddParameter("@Forfeit", entity.Forfeit);
            cmd.AddParameter("@MatchType", entity.MatchType);
            cmd.AddParameter("@NumberOfGames", entity.NumberOfGames);

            return connection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
