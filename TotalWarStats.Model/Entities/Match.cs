using System;
using System.Collections.Generic;
using System.Text;

namespace TotalWarStats.Model.Entities
{
    public class Match
    {
        public string MatchId { get; set; }
        public string PlayerFaction { get; set; }
        public string OpponentFaction { get; set; }
        public bool HasWon { get; set; }
        public DateTime Date { get; set; }
    }
}
