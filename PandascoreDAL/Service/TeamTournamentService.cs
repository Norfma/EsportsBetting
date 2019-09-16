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
    class TeamTournamentService : IUpdateService<TeamTournamentRegister>
    {
        public bool Update(TeamTournamentRegister entity)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("InsertTeamIntoTournament", true);

            cmd.AddParameter("@TeamId", entity.TeamId);
            cmd.AddParameter("@TournamentId", entity.TournamentId);

            return connection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
