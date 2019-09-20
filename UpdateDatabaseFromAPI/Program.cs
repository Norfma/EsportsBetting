using DALBase.Data;
using MyTools;
using Newtonsoft.Json;
using PandascoreDAL.Service;
using PandascoreUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UpdateDatabaseFromAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateTeamsAndPlayers.Update();
            UpdateTournaments.Update();
            UpdateMatchesAndGames.Update();
        }
    }
}
