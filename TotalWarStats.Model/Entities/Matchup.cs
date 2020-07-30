using System;
using System.Collections.Generic;
using System.Text;

namespace TotalWarStats.Model.Entities
{
    public class Matchup
    {
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public string PlayerFaction { get; set; }
        public string OpponentFaction { get; set; }
        public double Winrate { get; set; }
        public double WinLossesRatio { get; set; }

        public override string ToString()
        {
            return $"Winrate: {Winrate}\nWins: {MatchesWon} \nLosses: {MatchesLost}\n";
        }

        public string GetMatchup()
        {
            return $"{PlayerFaction} vs {OpponentFaction}";
        }
    }
}

