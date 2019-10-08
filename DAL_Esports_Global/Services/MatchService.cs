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
    class MatchService : IGetterService<Match, int>
    {
        public IEnumerable<Match> GetAll()
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Match");

            return connection.ExecuteReader<Match>(cmd, (c) => c.MapToGeneric<Match>());
        }

        public Match Get(int id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Match where Id = @Id");
            cmd.AddParameter("Id", id);

            return connection.ExecuteReader<Match>(cmd, (c) => c.MapToGeneric<Match>()).FirstOrDefault();
        }
    }
}
