using System;
using System.Collections.Generic;
using System.Text;

namespace TotalWarStats.Model.Entities
{
    public class Faction
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool HasAbbreviation { get; set; }
        public string Game { get; set; }
    }
}
