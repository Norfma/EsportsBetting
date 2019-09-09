using DAL_Esports_Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Esports_Global.Data
{
    public class Player : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string ImageURL { get; set; }
    }
}
