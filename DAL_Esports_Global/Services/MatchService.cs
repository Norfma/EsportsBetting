using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALBase;
using DALBase.Data;
using DALBase.Interfaces;
using DBToolbox;

namespace DAL_Esports_Global.Services
{
    public class MatchService : IGetterService<Match, int>
    {
        public IEnumerable<Match> GetAll()
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select *, T1.Name as Team1Name, T2.Name as Team2Name from v_Match join Team as T1 on Team1Id = T1.Id join Team as T2 on Team2Id = T2.Id");

            return connection.ExecuteReader<Match>(cmd, (c) => c.MapRecordToGeneric<Match>());
        }

        public Match Get(int id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select *, T1.Name as Team1Name, T2.Name as Team2Name from v_Match join Team as T1 on Team1Id = T1.Id join Team as T2 on Team2Id = T2.Id where v_Match.Id = @Id");
            cmd.AddParameter("Id", id);

            TeamService teamService = new TeamService();

            return connection.ExecuteReader<Match>(cmd, (c) => c.MapRecordToGeneric<Match>()).FirstOrDefault();
        }

        public IEnumerable<Game> GetGamesFromMatch(int matchId)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("GetGamesFromMatch", true);
            cmd.AddParameter("MatchId", matchId);

            return connection.ExecuteReader<Game>(cmd, (c) => c.MapRecordToGeneric<Game>());
        }
    }
}
