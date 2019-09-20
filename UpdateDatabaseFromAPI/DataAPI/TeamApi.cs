using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDatabaseFromAPI.DataAPI
{
    class TeamApi
    {
        public string Acronym { get; set; }
        public int Id { get; set; }
        [JsonProperty("image_url")]
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public List<PlayerApi> Players { get; set; }
    }
}
