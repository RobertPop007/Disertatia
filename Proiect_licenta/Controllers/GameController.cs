using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Disertatie_backend.Controllers
{
    public class GameController : BaseApiController
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IUserRepository _userRepository;

        public GameController(IGamesRepository gamesRepository, IUserRepository userRepository)
        {
            _gamesRepository = gamesRepository;
            _userRepository = userRepository;
        }

        [HttpPost("AddGame/{gameId}")]
        public async Task<ActionResult> AddGameForUser(ObjectId gameId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var game = await _gamesRepository.GetGameByIdAsync(gameId);
            if (game == null) return NotFound("Game not found");

            if (user.AppUserGame.Contains(gameId.ToString()) == true) return BadRequest("You have already added this game to your list");

            await _gamesRepository.AddGameToUser(user.Id, game.Id);

            return Ok(user);
        }

        [HttpGet("GetGamesFor/{username}")]
        public async Task<ActionResult> GetGamesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfGames = await _gamesRepository.GetUserGames(user.Id);
            return Ok(listOfGames);
        }

        [HttpGet("GetAllGames")]
        public async Task<ActionResult> GetGames([FromQuery] GameParams gameParams)
        {
            var games = await _gamesRepository.GetGamesAsync(gameParams);

            return Ok(games);
        }

        [HttpGet("{name}", Name = "GetGame")]
        public async Task<ActionResult<Game>> GetGame(string name)
        {
            return await _gamesRepository.GetGameByNameAsync(name);
        }

        [HttpGet("GameAlreadyAdded")]
        public async Task<bool> IsGameAlreadyAdded(ObjectId gameId)
        {
            var userId = User.GetUserId();

            return await _gamesRepository.IsGameAlreadyAdded(userId, gameId);
        }

        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeletegameForUser(ObjectId gameId)
        {
            var userId = User.GetUserId();

            var game = await  _gamesRepository.GetGameByIdAsync(gameId);
            if (game == null)
            {
                return NotFound();
            }

            await _gamesRepository.DeleteGameForUser(userId, gameId);

            return Ok();
        }
    }
}
