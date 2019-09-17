using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandascoreUtils;
using Newtonsoft.Json;
using DALBase.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using PandascoreDAL;
using System.Text.RegularExpressions;

namespace UpdatePlayersTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex(@"<(\S*)>");
            HttpClient client = new HttpClient();
            string Url = PandaScoreUtils.PandaBaseAddress + $"players?token={PandaScoreUtils.Token}&{PandaScoreUtils.MaxPerPage}";
            List<PlayerApi> players = new List<PlayerApi>();

            do
            {
                HttpResponseMessage msg = client.GetAsync(Url).Result;
                players.AddRange(JsonConvert.DeserializeObject<List<PlayerApi>>(msg.Content.ReadAsStringAsync().Result));

                IEnumerable<string> links;
                msg.Headers.TryGetValues("Link", out links);

                Url = links.First().Split(',').FirstOrDefault(s => s.Contains("rel=\"next\""));
                if (Url != null)
                {
                    Url = reg.Match(Url).Groups[1].Value;
                }
            } while (Url != null);
          
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
