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
    public class TournamentService : IUpdateService<Tournament>
    {
        public bool Update(Tournament entity)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("InsertTournament", true);

            cmd.AddParameter("@Id", entity.Id);
            cmd.AddParameter("@LagueName", entity.LeagueName);
            cmd.AddParameter("@SeriesFullName", entity.SeriesFullName);
            cmd.AddParameter("@Name", entity.Name);
            cmd.AddParameter("@ImageURL", entity.ImageURL);
            cmd.AddParameter("@BeginAt", entity.BeginAt);
            cmd.AddParameter("@EndAt", entity.EndAt);
            cmd.AddParameter("@Prizepool", entity.Prizepool);

            return connection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
