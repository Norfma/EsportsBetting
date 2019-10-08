using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALBase.Interfaces;
using DALBase.Data;
using DBToolbox;
using DALBase;

namespace DAL_Esports_Global.Services
{
    class UserService : IRepository<User, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_User where Active = 1");

            return connection.ExecuteReader<User>(cmd, (c) => c.MapToGeneric<User>());
        }

        public User Get(int id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_User where id = @id and Active = 1");
            cmd.AddParameter("Id", id);

            return connection.ExecuteReader<User>(cmd, (c) => c.MapToGeneric<User>()).FirstOrDefault();
        }

        public int Insert(User entity)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("InsertUser", true);
            cmd.AddParameter("Username", entity.Username);
            cmd.AddParameter("Hash", entity.Hashpwd);
            cmd.AddParameter("Salt", entity.Salt);

            return (int)connection.ExecuteScalar(cmd);
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
