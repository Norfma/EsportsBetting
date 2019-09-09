﻿using DAL_Esports_Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Esports_Global.Data
{
    /// <summary>
    /// Only used to find which teams are participating in a tournament.
    /// </summary>
    public class TeamTournamentRegister
    {
        public int TeamId { get; set; }
        public int TournamentId { get; set; }
    }
}
