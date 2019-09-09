using DAL_Esports_Global.Data;
using DAL_Esports_Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Esports_Global.Service
{
    class PlayerService : IRepository<Player, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> Get()
        {
            throw new NotImplementedException();
        }

        public Player Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Player entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Player entity)
        {
            throw new NotImplementedException();
        }
    }
}
