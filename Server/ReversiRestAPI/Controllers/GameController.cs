using Microsoft.AspNetCore.Mvc;
using ReversiRestAPI.Helpers;
using ReversiRestAPI.Models;
using ReversiRestAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReversiRestAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase {

        private readonly IGameRepository iRepository;

        public GameController(IGameRepository repository) {
            iRepository = repository;
        }

        // GET api/game
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetGameDescriptionsOfGamesWithWaitingPlayer([FromQuery] bool waiting) {
            var games = iRepository.GetGames();
            if (!waiting)
                return Ok(games);
            var gameDescriptions = games.Where(g => g.HasWaitingPlayer()).Select(g => g.Description);
            return Ok(gameDescriptions);
        }

        [HttpPost]
        public ActionResult NewGame([FromBody] NewGameRequest ngr) {
            if (!TokenValidator.ValidatePlayerToken(ngr.PlayerToken))
                return BadRequest();

            Game newGame = new Game {
                Description = ngr.GameDescription
            };
            if (ngr.PlayerPickedWhite)
                newGame.Player1Token = ngr.PlayerToken;
            else
                newGame.Player2Token = ngr.PlayerToken;

            newGame.Token = TokenGenerator.GenerateGameToken(ngr.PlayerToken);
            iRepository.AddGame(newGame);
            return CreatedAtAction("NewGame", newGame);
        }

        [HttpGet("{token}")]
        public ActionResult<Game> GetGameByTokenReq(string token) {
            if (!(token.StartsWith('G') || token.StartsWith('P')))
                return BadRequest();
            Game game = GetGameByToken(token);
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        [HttpGet("{token}/turn")]
        public ActionResult<Colour> GetTurn(string token) {
            Game game = GetGameByToken(token);
            if (game == null)
                return NotFound();
            return Ok(game.Turn);
        }

        [HttpPut("move")]
        public ActionResult<bool> DoMove([FromBody] MoveRequest moveRequest, bool pass) {
            if (moveRequest == null || moveRequest?.Coordinates == null || string.IsNullOrEmpty(moveRequest?.GameToken) || string.IsNullOrEmpty(moveRequest?.PlayerToken))
                return BadRequest();
            Game game = GetGameByToken(moveRequest.GameToken);

            //Check if it's even the player's turn
            if ((moveRequest.PlayerToken == game.Player1Token && game.Turn != Colour.White) || (moveRequest.PlayerToken == game.Player2Token && game.Turn != Colour.White))
                return BadRequest();

            if (pass)
                return Ok(game.Pass());
            else
                return Ok(game.DoMove(moveRequest.Coordinates.Y, moveRequest.Coordinates.Y));
        }

        [HttpPut("concede")]
        public ActionResult<bool> GiveUp([FromBody] SurrenderRequest sr) {
            if (sr == null || string.IsNullOrEmpty(sr?.GameToken) || string.IsNullOrEmpty(sr?.PlayerToken))
                return BadRequest();
            return Ok(true);
        }

        [NonAction]
        public Game GetGameByToken(string token) {
            Game game = null;
            if (token.StartsWith('G'))
                game = iRepository.GetGames().FirstOrDefault(g => g.Token == token);
            else if (token.StartsWith('P'))
                game = iRepository.GetGames().FirstOrDefault(g => g.Player1Token == token || g.Player2Token == token);
            return game;
        }
    }
}
