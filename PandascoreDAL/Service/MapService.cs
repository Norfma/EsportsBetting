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
    public class MapService : IUpdateService<Map>
    {
        public bool Update(Map entity)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("InsertMap", true);

            cmd.AddParameter("@Id", entity.Id);
            cmd.AddParameter("@Name", entity.Name);
            cmd.AddParameter("@GameMode", entity.GameMode);
            cmd.AddParameter("@ImageURL", entity.ImageURL);

            return connection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
