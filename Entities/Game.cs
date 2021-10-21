using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Entities
{
    public class Game
    {
        public string GameId { get; set; }
        public DateTime Created { get; set; }
        public string Passcode { get; set; }
        public List<Player> Players { get; set; }
        public List<PlayerResult> MatchesResults { get; set; }
        public List<PlayerResult> Tied { get; set; }
        public PlayerResult Winner { get; set; }
        public bool HasWinner { get; set; }

        //Cria um UID para a partida
        public Game()
        {
            this.GameId = Guid.NewGuid().ToString();
            this.Created = DateTime.Now;
        }

    }
}




