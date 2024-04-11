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
        private readonly IUserItemsRepository<Game> _userItemsRepository;

        public GameController(IGamesRepository gamesRepository, 
            IUserRepository userRepository,
            IUserItemsRepository<Game> userItemsRepository)
        {
            _gamesRepository = gamesRepository;
            _userRepository = userRepository;
            _userItemsRepository = userItemsRepository;
        }

        [HttpPost("AddGameToUser/{gameId}")]
        public async Task<IActionResult> AddGameForUser(ObjectId gameId)
        {
            var username = User.GetUsername();

            if (username == null) return BadRequest("User does not exist");

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var game = await _gamesRepository.GetGameByIdAsync(gameId);
            if (game == null) return NotFound("Game not found");

            if (user.AppUserGame.Contains(gameId.ToString()) == true) return BadRequest("You have already added this game to your list");

            await _userItemsRepository.AddItemToUser<Game>(user, gameId);

            return Ok(user);
        }

        [HttpGet("GetGamesFor/{username}")]
        public async Task<IActionResult> GetGamesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfGames = await _userItemsRepository.GetItemForUser<Game>(user.Id);
            return Ok(listOfGames);
        }

        [HttpGet("GetAllGames")]
        public async Task<IActionResult> GetGames([FromQuery] GameParams gameParams)
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

            return await _userItemsRepository.IsItemAlreadyAdded(userId, gameId);
        }

        [HttpDelete("DeleteGameFromUser/{gameId}")]
        public async Task<IActionResult> DeletegameForUser(ObjectId gameId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            var game = await  _gamesRepository.GetGameByIdAsync(gameId);
            if (game == null)
            {
                return NotFound();
            }

            await _userItemsRepository.DeleteItemFromUser<Game>(user, gameId);

            return Ok();
        }
    }
}
