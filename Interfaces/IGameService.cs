using RockPaperScissorsGame.DTOs;
using RockPaperScissorsGame.Entities;

namespace RockPaperScissorsGame.Interfaces {
    public interface IGameService{
        Game Create(PlayerDTO playerDTO);
    }
}