using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDatabaseFromAPI.DataAPI
{
    class GameApi
    {

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }
        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        public bool Finished { get; set; }
        public bool Forfeit { get; set; }
        public int Id { get; set; }
        public int? Length { get; set; }
        public int? MatchId { get; set; }
        public int Position { get; set; }
        public string Status { get; set; }
        public Winner Winner { get; set; }
    }

    class Winner
    {
        public int? Id { get; set; }
    }
}
