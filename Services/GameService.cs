using System;
using System.Collections.Generic;
using RockPaperScissorsGame.DTOs;
using RockPaperScissorsGame.Entities;
using RockPaperScissorsGame.Interfaces;

namespace RockPaperScissorsGame.Services
{
    public class GameService : IGameService
    {
        public Game Create(PlayerDTO playerDTO)
        {
            int totalOpponents = playerDTO.GetTotalOpponentsOrDefault();
            List<Player> participants = new List<Player>();

            participants.Add(new Player { Name = string.IsNullOrEmpty(playerDTO.Name) ? "Jogador sem nome" : playerDTO.Name, ChosenOption = playerDTO.GetValidChosenOptionOrNull() });

            //Cria participantes fakes para competir com o jogador que inputou
            //os dados
            for (var i = 0; i < totalOpponents; i++)
            {

                //Gera uma opção aleatória
                Random rnd = new Random();
                int index = rnd.Next(ApplicationValues.validOptions.Count);

                Player fakePlayer = new Player { Name = string.Concat("NPC ", i + 1), ChosenOption = ApplicationValues.validOptions[index] };
                participants.Add(fakePlayer);
            }

            Game theGame = new Game { Players = participants };

            return theGame;
        }
    }
}