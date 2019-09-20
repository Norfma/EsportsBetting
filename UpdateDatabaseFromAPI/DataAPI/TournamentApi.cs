using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDatabaseFromAPI.DataAPI
{
    class TournamentApi
    {
        public int Id { get; set; }
        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }
        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }
        public League League { get; set; }
        public Serie Serie { get; set; }
        public string Name { get; set; }
        public string Prizepool { get; set; }
        public TeamApi[] Teams { get; set; }
    }

    public class Serie
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }

    public class League
    {
        [JsonProperty("image_url")]
        public string ImageURL { get; set; }
        public string Name { get; set; }
    }
}
