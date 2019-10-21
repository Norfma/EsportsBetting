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
    public class PlayerService : IGetterService<Player, int>
    {
        public IEnumerable<Player> GetAll()
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Player");

            return connection.ExecuteReader<Player>(cmd, (c)=>c.MapToGeneric<Player>());
        }

        public Player Get(int id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Player where Id = @Id");
            cmd.AddParameter("Id", id);

            return connection.ExecuteReader<Player>(cmd, (c) => new Player()
            {
                Id = (int)c["Id"],
                ImageURL = c["ImageURL"].ToString(),
                Name = c["Name"].ToString(),
                TeamId = (int)c["TeamId"]
            }).FirstOrDefault();
        }
    }
}
