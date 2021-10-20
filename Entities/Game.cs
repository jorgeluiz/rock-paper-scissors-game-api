using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Entities
{
    public class Game
    {
        public string Uid { get; set; }
        public DateTime Created { get; set; }
        public string Passcode { get; set; }
        public List<Player> Players { get; set; }
        public List<GameResult> GameResult { get; set; }
        public Player Winner { get; set; }
    }
}




