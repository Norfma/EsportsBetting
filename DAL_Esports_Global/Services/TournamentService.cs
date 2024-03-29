﻿using System;
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
    public class TournamentService : IGetterService<Tournament, int>
    {
        public IEnumerable<Tournament> GetAll()
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Tournament");

            return connection.ExecuteReader<Tournament>(cmd, (c) => c.MapRecordToGeneric<Tournament>());
        }

        public Tournament Get(int id)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select * from v_Tournament where Id = @Id");
            cmd.AddParameter("Id", id);

            return connection.ExecuteReader<Tournament>(cmd, (c) => c.MapRecordToGeneric<Tournament>()).FirstOrDefault();
        }

        public IEnumerable<Tournament>GetTournamentsOfTeam(int TeamId)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("" +
                "select v_Tournament.* " +
                "from v_TournamentTeam as TT " +
                "join v_Tournament as VT on VT.id = TT.TournamentId " +
                "where TT.TeamId = @TeamId"
                );
            cmd.AddParameter("TeamId", TeamId);

            return connection.ExecuteReader<Tournament>(cmd, (c) => c.MapRecordToGeneric<Tournament>());
        }

        /// <summary>
        /// Gets the number of available matches the user can bet on in a specific tournament.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="TournamentId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetNumberOfAvailableMatches(int UserId, int TournamentId, DateTime date)
        {
            Connection connection = new Connection(DBConfig.CONNSTRING);
            Command cmd = new Command("select dbo.GetAvailableMatchesFromTournament(@UserId, @TournamentId, @Date) as counts");
            cmd.AddParameter("UserId", UserId);
            cmd.AddParameter("TournamentId", TournamentId);
            cmd.AddParameter("Date", date);

            return (int)connection.ExecuteScalar(cmd);
        }
    }
}
