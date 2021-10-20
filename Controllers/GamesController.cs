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
        public GamesController(
            IGameService gameService
            )
        {
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult PlayTheGame([FromBody] PlayerDTO playerDTO)
        {
            if (!string.IsNullOrEmpty(playerDTO.GetValidChosenOptionOrNull()))
            {
                //Cria um jogo, que já tem um resultado processado
                Game theGame = _gameService.Create(playerDTO);
                return Ok(theGame);
            }
            else
            {
                return BadRequest(new { message = "Por favor, informe uma opção" });
            }
        }
    }
}
