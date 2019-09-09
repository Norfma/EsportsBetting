﻿using DAL_Esports_Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Esports_Global.Data
{
    public class Tournament : IEntity<int>
    {
        public int Id { get; set; }
        public string LeagueName { get; set; }
        public string SeriesFullName { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public DateTime BeginAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Prizepool { get; set; }
    }
}