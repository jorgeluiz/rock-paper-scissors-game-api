using RockPaperScissorsGame.DTOs;
using RockPaperScissorsGame.Entities;

namespace RockPaperScissorsGame.Interfaces {
    public interface IGameService{
        Game Create(PlayerDTO playerDTO);
        Game ProcessResults(Game game);
        Game GameResult(Game game);
        string MatchResult(string playerOneChosenOption, string playerTwoChosenOption);
    }
}