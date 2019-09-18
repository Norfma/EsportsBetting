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
    public class TeamService : IUpdateService<Team>
    {
        public bool Update(Team entity)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("InsertPlayer", true);

            cmd.AddParameter("@Id", entity.Id);
            cmd.AddParameter("@Name", entity.Name);
            cmd.AddParameter("@TeamId", entity.Acronym);
            cmd.AddParameter("@ImageURL", entity.ImageURL);

            return connection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
