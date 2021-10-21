using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Entities
{
    public class PlayerResult
    {
        public string PlayerResultId { get; set; }
        public DateTime Created { get; set; }
        public Player Player { get; set; }
        public List<Player> WonMatches { get; set; }
        public List<Player> LosedMatches { get; set; }
        public List<Player> TiedMatches { get; set; }
        public List<Player> InvalidMatches { get; set; }
        public int totalWins { get; set; }
        public int totalLoses { get; set; }
        public int totalDraws { get; set; }
        public int totalInvalid { get; set; }
        //O score de um jogador é o resultado da quantidade de vitórias menos a de derrotas
        public int score {get; set;}

        public PlayerResult()
        {
            this.PlayerResultId = Guid.NewGuid().ToString();
            this.Created = DateTime.Now;
        }
    }
}




