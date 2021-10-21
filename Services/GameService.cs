using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
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

            Game theGame = this.ProcessResults(new Game { Players = participants, MatchesResults = new List<PlayerResult>() });
            return theGame;
        }

        //Processa um jogo pra definir resultados e o vencedor
        public Game ProcessResults(Game game)
        {

            //Processa e armazena o resultado de cada jogo
            foreach (Player player in game.Players)
            {
                string playerName = player.Name;
                string playerId = player.PlayerId;
                string playerChosenOption = player.ChosenOption;

                List<Player> wonMatches = new List<Player>();
                List<Player> losedMatches = new List<Player>();
                List<Player> tiedMatches = new List<Player>();
                List<Player> invalidMatches = new List<Player>();
                int totalWins = 0;
                int totalLoses = 0;
                int totalDraws = 0;
                int totalInvalid = 0;
                int playerScore = 0;

                //Verifica o resultado de cada
                //jogador da partida
                foreach (Player anotherPlayer in game.Players)
                {
                    //Realiza a conferência em todos os outros jogadores da partida
                    //TODO: verificar se essa é a melhor forma fazer a comparação
                    if (!player.PlayerId.Equals(anotherPlayer.PlayerId))
                    {
                        string anotherPlayerId = anotherPlayer.PlayerId;
                        string anotherPlayerName = anotherPlayer.Name;
                        string anotherPlayerChosenOption = anotherPlayer.ChosenOption;

                        //Verifica os resultados da partida
                        string result = this.MatchResult(playerChosenOption, anotherPlayerChosenOption);

                        switch (result)
                        {
                            case ApplicationValues.RESULT_WIN:
                                {
                                    wonMatches.Add(anotherPlayer);
                                    totalWins++;
                                }
                                break;
                            case ApplicationValues.RESULT_LOSE:
                                {
                                    losedMatches.Add(anotherPlayer);
                                    totalLoses++;
                                }
                                break;
                            case ApplicationValues.RESULT_DRAW:
                                {
                                    tiedMatches.Add(anotherPlayer);
                                    totalDraws++;
                                }
                                break;
                            default:
                                {
                                    invalidMatches.Add(anotherPlayer);
                                    totalInvalid++;
                                }
                                break;
                        }
                    }
                }

                playerScore = totalWins - totalLoses;

                PlayerResult matchResult = new PlayerResult
                {
                    Player = player,
                    WonMatches = wonMatches,
                    LosedMatches = losedMatches,
                    TiedMatches = tiedMatches,
                    InvalidMatches = invalidMatches,
                    totalWins = totalWins,
                    totalLoses = totalLoses,
                    totalDraws = totalDraws,
                    totalInvalid = totalInvalid,
                    score = playerScore
                };
                game.MatchesResults.Add(matchResult);
            }
            Game output = this.GameResult(game);
            return output;
        }

        //Verifica o resultado de uma partida de acordo com as regras do jogo
        public string MatchResult(string playerOneOpt, string playerTwoOpt)
        {
            string output = null;

            if (ApplicationValues.rules.ContainsKey(playerOneOpt))
            {
                var possibileResults = ApplicationValues.rules[playerOneOpt];
                if (possibileResults.ContainsKey(playerTwoOpt))
                {
                    output = possibileResults[playerTwoOpt];
                }
            }

            return output;
        }

        //A partir dos resultados do jogo, calcula o resultado final do jogo
        public Game GameResult(Game game){
            
            List<PlayerResult> ties = new List<PlayerResult>();
            Player winner = null;
            bool hasWinner = false;

            SortedDictionary<int, List<PlayerResult>> orderedScores = new SortedDictionary<int, List<PlayerResult>>();
            
            foreach(PlayerResult playerResult in game.MatchesResults){
                if(orderedScores.ContainsKey(playerResult.score)){
                    orderedScores[playerResult.score].Add(playerResult);
                } else {
                    List<PlayerResult> playersResults = new List<PlayerResult>();
                    playersResults.Add(playerResult);
                    orderedScores.Add(playerResult.score, playersResults);
                }
            }

            //Inverte o resultado pois a ordenaçao padrão do 
            //dicionário é ascendente
            var ranking = orderedScores.Reverse();
            var firstItem = ranking.First();

            //Se tiver mais de um item na lista, houve empate
            if(firstItem.Value.Count() > 1){
                hasWinner = false;
                ties = firstItem.Value;
            } else {
                hasWinner = true;
                winner = firstItem.Value.First().Player;
            }
            
            game.HasWinner = hasWinner;
            game.Winner = winner;
            game.Tied = ties;

            return game;
        }

    }
}