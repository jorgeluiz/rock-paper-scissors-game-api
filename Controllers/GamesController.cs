using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsGame.DTOs;
using RockPaperScissorsGame.Entities;
using RockPaperScissorsGame.Interfaces;

namespace RockPaperScissorsGame.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IGameResultService _gameResultService;
        public GamesController(
            IGameService gameService,
            IGameResultService gameResultService
            )
        {
            _gameService = gameService;
            _gameResultService = gameResultService;
        }

        [HttpPost]
        public IActionResult PlayTheGame([FromBody] PlayerDTO playerDTO)
        {
            if (!string.IsNullOrEmpty(playerDTO.ChosenOption))
            {
                Game newGame = _gameService.Create(playerDTO);
                GameResult gameResult = _gameResultService.GetResult(newGame);
                return Ok(newGame);
            }
            else
            {
                return BadRequest(new { message = "Por favor, informe uma opção" });
            }
        }
    }
}
