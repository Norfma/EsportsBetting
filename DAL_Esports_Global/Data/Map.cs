﻿using DAL_Esports_Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Esports_Global.Data
{
    /// <summary>
    /// One of the Game Map
    /// </summary>
    public class Map : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GameMode { get; set; }
        public string ImageURL { get; set; }
    }
}
