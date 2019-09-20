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
    public class GameService : IUpdateService<Game>
    {
        public bool Update(Game entity)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("InsertGame", true);

            cmd.AddParameter("@Id", entity.Id);
            cmd.AddParameter("@MatchId", entity.MatchId);
            cmd.AddParameter("@WinnerId", entity.WinnerId);
            cmd.AddParameter("@BeginAt", entity.BeginAt);
            cmd.AddParameter("@EndAt", entity.EndAt);
            cmd.AddParameter("@Forfeit", entity.Forfeit);
            cmd.AddParameter("@Finished", entity.Finished);
            cmd.AddParameter("@Length", entity.Length);
            cmd.AddParameter("@Position", entity.Position);
            cmd.AddParameter("@Status", entity.Status);


            return connection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
