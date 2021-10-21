using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Entities
{
    public class Player
    {
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public string ChosenOption { get; set; }
        public DateTime Created { get; set; }

        //Cria um UID para o jogador
        public Player()
        {
            this.PlayerId = Guid.NewGuid().ToString();
            this.Created = DateTime.Now;
        }

    }
}




