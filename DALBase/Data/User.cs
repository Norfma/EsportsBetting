using DALBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBase.Data
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Hashpwd { get; set; }
        public string Salt { get; set; }
        public bool Active { get; set; }
    }
}
