using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.Entities;
using Proiect_licenta.Entities.Games.Game;
using Proiect_licenta.Extensions;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Threading.Tasks;

namespace Proiect_licenta.Controllers
{
    public class GameController : BaseApiController
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GameController(DataContext context, IGamesRepository gamesRepository, IMapper mapper, IUserRepository userRepository)
        {
            _gamesRepository = gamesRepository;
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("AddGame/{gameId}")]
        public async Task<ActionResult> AddGameForUser(int gameId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var game = await _gamesRepository.GetGameByIdAsync(gameId);
            if (game == null) return NotFound("Game not found");

            var appUsergameItem = new AppUserGameItem
            {
                AppUserId = user.Id,
                GameId = gameId
            };

            var alreadyAdded = await _context.AppUserGameItems.AnyAsync(o => o.AppUserId == user.Id && o.GameId == gameId);

            if (alreadyAdded == true) return BadRequest("You have already added this game to your list");

            await _context.AppUserGameItems.AddAsync(appUsergameItem);
            user.AppUserGame.Add(appUsergameItem);

            await _userRepository.SaveAllAsync();

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet("GetGamesFor/{username}")]
        public async Task<ActionResult> GetGamesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfGames = await _gamesRepository.GetUserGames(user.Id);
            return Ok(listOfGames);
        }

        [HttpGet("GetAllgames")]
        public async Task<ActionResult> Getgames([FromQuery] GameParams gameParams)
        {
            var games = await _gamesRepository.GetGamesAsync(gameParams);

            //Response.AddPaginationHeader(games.CurrentPage, games.PageSize, games.TotalCount, games.TotalPages);

            return Ok(games);
        }

        [HttpGet("{fullTitle}", Name = "GetGame")]
        public async Task<ActionResult<Game>> Getgame(string fullTitle)
        {
            return await _gamesRepository.GetGameByFullTitleAsync(fullTitle);
        }

        [HttpGet("GameAlreadyAdded")]
        public bool IsGameAlreadyAdded(int gameId)
        {
            var userId = User.GetUserId();

            return _gamesRepository.IsGameAlreadyAdded(userId, gameId);
        }

        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeletegameForUser(int gameId)
        {
            var userId = User.GetUserId();

            var game = await _context.Games.FindAsync(gameId);
            if (game == null)
            {
                return NotFound();
            }

            _gamesRepository.DeleteGameForUser(userId, gameId);

            if (await _gamesRepository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting the game for this user");
        }
    }
}
