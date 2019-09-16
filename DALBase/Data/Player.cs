using DALBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DALBase.Data
{
    public class Player : IEntity<int>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("current_team.id")]
        public int TeamId { get; set; }
        [JsonProperty("image_url")]
        public string ImageURL { get; set; }
    }
}
