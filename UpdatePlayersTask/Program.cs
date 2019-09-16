using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PandascoreUtils;
using Newtonsoft.Json;
using DALBase.Data;

namespace UpdatePlayersTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = PandaScoreUtils.PandaBaseAddress;

            HttpResponseMessage msg = client.GetAsync($"players?token={PandaScoreUtils.Token}").Result;
            List<PlayerApi> o = JsonConvert.DeserializeObject<List<PlayerApi>>(msg.Content.ReadAsStringAsync().Result);

            Console.ReadLine();
        }
    }

    class PlayerContainer
    {
        List<PlayerApi> playerApi { get; set; }
    }

    class PlayerApi
    {
        [JsonProperty("current_team")]
        CurrentTeam Current_Team { get; set; }
        public int id { get; set; }
        public string Name { get; set; }
        public string Image_Url { get; set; }
    }

    class CurrentTeam
    {
        public int id { get; set; }
    }
}
