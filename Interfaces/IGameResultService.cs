using RockPaperScissorsGame.Entities;

namespace RockPaperScissorsGame.Interfaces {
    public interface IGameResultService{
        GameResult GetResult(Game game);
    }
}