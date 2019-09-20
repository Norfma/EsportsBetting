using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDatabaseFromAPI.DataAPI
{
    class PlayerApi
    {
        public int Id { get; set; }
        [JsonProperty("image_url")]
        public string ImageURL { get; set; }
        public string Name { get; set; }
    }
}
