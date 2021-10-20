using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Entities
{
    public class Game
    {
        public string Uid { get; set; }
        public DateTime Created { get; set; }
        public string Passcode { get; set; }
        public List<Player> players { get; set; }
        public List<GameResult> gameResult { get; set; }
        public Player winner { get; set; }
    }
}




