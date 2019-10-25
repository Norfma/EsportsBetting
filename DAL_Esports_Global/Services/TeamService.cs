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
    public class TeamService : IGetterService<Team, int>
    {
        public IEnumerable<Team> GetAll()
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Team");

            return connection.ExecuteReader<Team>(cmd, (c) => c.MapRecordToGeneric<Team>());
        }

        public Team Get(int id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Team where Id = @Id");
            cmd.AddParameter("Id", id);

            return connection.ExecuteReader<Team>(cmd, (c) => c.MapRecordToGeneric<Team>()).FirstOrDefault();
        }
    }
}
