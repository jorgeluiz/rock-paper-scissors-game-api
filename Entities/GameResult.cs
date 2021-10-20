using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Entities
{
    public class GameResult
    {
        public string Uid { get; set; }
        public DateTime Created { get; set; }
        public string Passcode { get; set; }
        public Player player { get; set; }
        public List<Player> wonMatches {get; set;}
        public List<Player> losedMatches {get; set;}
        public List<Player> tiedWith {get; set;}
        public int totalWins {get; set;}
        public int totalLoses {get; set;}
        public int totalDraws {get; set;}
    }
}




