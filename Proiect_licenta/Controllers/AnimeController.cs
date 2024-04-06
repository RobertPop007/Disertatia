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
        private readonly IUserAnimeRepository _userAnimeRepository;

        public AnimeController(IAnimeRepository animesRepository, IUserRepository userRepository, IUserAnimeRepository userAnimeRepository)
        {
            _animesRepository = animesRepository;
            _userRepository = userRepository;
            _userAnimeRepository = userAnimeRepository;
        }


        //facem cumva sa avem acele colectii numai in repo
        [HttpPost("AddAnime/{animeId}")]
        public async Task<ActionResult> AddAnimeForUser(ObjectId animeId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var anime = await _animesRepository.GetAnimeByIdAsync(animeId);
            if (anime == null) return NotFound("Anime not found");

            if (user.AppUserAnime.Contains(anime.Id) == true) return BadRequest("You have already added this anime to your list");

            await _animesRepository.AddAnimeToUser(user.Id, anime.Id);

            return Ok(user);
        }

        [HttpGet("GetAnimesFor/{username}")]
        public async Task<ActionResult> GetAnimesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfAnimes = await _animesRepository.GetUserAnimes(user.Id);
            return Ok(listOfAnimes);
        }

        [HttpGet("GetAllAnimes")]
        public async Task<ActionResult> GetAnimes([FromQuery] AnimeParams animeParams)
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

            return await _animesRepository.IsAnimeAlreadyAdded(userId, animeId);
        }

        [HttpDelete("{animeId}")]
        public async Task<IActionResult> DeleteAnimeForUser(ObjectId animeId)
        {
            var userId = User.GetUserId();

            var anime = await _animesRepository.GetAnimeByIdAsync(animeId);
            if (anime == null)
            {
                return NotFound();
            }

            await _animesRepository.DeleteAnimeForUser(userId, animeId);

            return Ok();
        }
    }
}
