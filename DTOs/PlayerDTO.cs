using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame.DTOs
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string ChosenOption { get; set; }
        public int? totalOpponents { get; set; }

        public string GetValidChosenOptionOrNull()
        {
            return "";
        }

    }

}




