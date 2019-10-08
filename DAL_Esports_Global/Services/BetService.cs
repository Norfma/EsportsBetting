using DALBase;
using DALBase.Data;
using DALBase.Interfaces;
using DBToolbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Esports_Global.Services
{
    class BetService
    {
        public bool Delete(int[] id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("DeleteBet");
            cmd.AddParameter("userId", id[0]);
            cmd.AddParameter("matchId", id[1]);

            return connection.ExecuteNonQuery(cmd) > 0;
        }

        public IEnumerable<Bet> Get(int userId)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Bet where UserId = @userId");
            cmd.AddParameter("userId", userId);

            return connection.ExecuteReader<Bet>(cmd, (c) => c.MapToGeneric<Bet>());
        }

        public Bet Get(int[] id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Bet where UserId = @userId and MatchId = @matchId");
            cmd.AddParameter("userId", id[0]);
            cmd.AddParameter("matchId", id[1]);

            return connection.ExecuteReader<Bet>(cmd, (c) => c.MapToGeneric<Bet>()).FirstOrDefault();
        }

        public bool Insert(Bet entity)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("InsertBet");
            cmd.AddParameter("userId", entity.UserId);
            cmd.AddParameter("matchId", entity.MatchId);
            cmd.AddParameter("bettedWinner", entity.BettedWinner);

            return connection.ExecuteNonQuery(cmd) > 0;
        }

        public bool Update(Bet entity)
        {
            if (this.Delete(entity.Id))
            {
                return this.Insert(entity);
            }
            return false;
        }
    }
}
