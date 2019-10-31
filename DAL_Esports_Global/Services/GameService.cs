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
    public class GameService : IGetterService<Game, int>
    {
        public IEnumerable<Game> GetAll()
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Game");

            return connection.ExecuteReader<Game>(cmd, (c) => c.MapRecordToGeneric<Game>());
        }

        public Game Get(int id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Game where Id = @Id");
            cmd.AddParameter("Id", id);

            return connection.ExecuteReader<Game>(cmd, (c) => c.MapRecordToGeneric<Game>()).FirstOrDefault();
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
