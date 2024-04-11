using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Disertatie_backend.Controllers
{
    public class AnimeController : BaseApiController
    {
        private readonly IAnimeRepository _animesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserItemsRepository<Datum> _userItemsRepository;

        public AnimeController(IAnimeRepository animesRepository, 
            IUserRepository userRepository,
            IUserItemsRepository<Datum> userItemsRepository)
        {
            _animesRepository = animesRepository;
            _userRepository = userRepository;
            _userItemsRepository = userItemsRepository;
        }

        [HttpPost("AddAnimeToUser/{animeId}")]
        public async Task<IActionResult> AddAnimeForUser(ObjectId animeId)
        {
            var username = User.GetUsername();

            if (username == null) return BadRequest("User does not exist");

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var anime = await _animesRepository.GetAnimeByIdAsync(animeId);
            if (anime == null) return NotFound("Anime not found");

            if (user.AppUserAnime.Contains(anime.Id.ToString()) == true) return BadRequest("You have already added this anime to your list");

            await _userItemsRepository.AddItemToUser<Datum>(user, animeId);

            return Ok(user);
        }

        [HttpGet("GetAnimesFor/{username}")]
        public async Task<IActionResult> GetAnimesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfAnimes = await _userItemsRepository.GetItemForUser<Datum>(user.Id);
            return Ok(listOfAnimes);
        }

        [HttpGet("GetAllAnimes")]
        public async Task<IActionResult> GetAnimes([FromQuery] AnimeParams animeParams)
        {
            var animes = await _animesRepository.GetAnimesAsync(animeParams);
            return Ok(animes);
        }

        [HttpGet("{title}", Name = "GetAnime")]
        public async Task<ActionResult<Datum>> GetAnime(string title)
        {
            return await _animesRepository.GetAnimeByFullTitleAsync(title);
        }

        [HttpGet("AnimeAlreadyAdded")]
        public async Task<bool> IsAnimeAlreadyAdded(ObjectId animeId)
        {
            var userId = User.GetUserId();

            return await _userItemsRepository.IsItemAlreadyAdded(userId, animeId);
        }

        [HttpDelete("DeleteAnimeFromUser/{animeId}")]
        public async Task<IActionResult> DeleteAnimeForUser(ObjectId animeId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            var anime = await _animesRepository.GetAnimeByIdAsync(animeId);
            if (anime == null)
            {
                return NotFound();
            }

            await _userItemsRepository.DeleteItemFromUser<Datum>(user, animeId);

            return Ok();
        }
    }
}
