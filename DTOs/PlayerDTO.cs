using System;
using System.Collections.Generic;
using RockPaperScissorsGame;

namespace RockPaperScissorsGame.DTOs
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string ChosenOption { get; set; }
        public int? TotalOpponents { get; set; }

        //Retorna a opção em formato lower case, 
        //se estiver na lista de opções válidas, ou então retorna nulo
        public string GetValidChosenOptionOrNull()
        {
            string output = null;
            string chosenOption = this.ChosenOption.ToLower();

            if (ApplicationValues.validOptions.Contains(chosenOption))
            {
                output = chosenOption;
            }
            return output;
        }

        //Retorna a opção em formato lower case, 
        //se estiver na lista de opções válidas, ou então retorna nulo
        public int GetTotalOpponentsOrDefault()
        {
            int output = 1;
            if (this.TotalOpponents != null && this.TotalOpponents > 1)
            {
                output = this.TotalOpponents.GetValueOrDefault(1);
            }
            return output;

        }

    }

}




