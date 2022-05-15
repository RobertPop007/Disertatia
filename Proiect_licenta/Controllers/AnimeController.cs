using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.Entities;
using Proiect_licenta.Entities.Anime;
using Proiect_licenta.Extensions;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Threading.Tasks;

namespace Proiect_licenta.Controllers
{
    public class AnimeController : BaseApiController
    {
        private readonly IAnimeRepository _animesRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AnimeController(DataContext context, IAnimeRepository animesRepository, IMapper mapper, IUserRepository userRepository)
        {
            _animesRepository = animesRepository;
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("AddAnime/{animeId}")]
        public async Task<ActionResult> AddAnimeForUser(int animeId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var anime = await _animesRepository.GetAnimeByIdAsync(animeId);
            if (anime == null) return NotFound("Anime not found");

            var appUserAnimeItem = new AppUserAnimeItem
            {
                AppUserId = user.Id,
                AnimeId = animeId
            };

            var alreadyAdded = await _context.AppUserAnimeItems.AnyAsync(o => o.AppUserId == user.Id && o.AnimeId == animeId);

            if (alreadyAdded == true) return BadRequest("You have already added this anime to your list");

            await _context.AppUserAnimeItems.AddAsync(appUserAnimeItem);
            user.AppUserAnime.Add(appUserAnimeItem);

            await _userRepository.SaveAllAsync();

            await _context.SaveChangesAsync();

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

            //Response.AddPaginationHeader(animes.CurrentPage, animes.PageSize, animes.TotalCount, animes.TotalPages);

            return Ok(animes);
        }

        [HttpGet("{title}", Name = "GetAnime")]
        public async Task<ActionResult<Datum>> GetAnime(string title)
        {
            return await _animesRepository.GetAnimeByFullTitleAsync(title);
        }

        [HttpGet("AnimeAlreadyAdded")]
        public bool IsAnimeAlreadyAdded(int animeId)
        {
            var userId = User.GetUserId();

            return _animesRepository.IsAnimeAlreadyAdded(userId, animeId);
        }

        [HttpDelete("{animeId}")]
        public async Task<IActionResult> DeleteAnimeForUser(int animeId)
        {
            var userId = User.GetUserId();

            var anime = await _context.Anime.FindAsync(animeId);
            if (anime == null)
            {
                return NotFound();
            }

            _animesRepository.DeleteAnimeForUser(userId, animeId);

            if (await _animesRepository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting the anime for this user");
        }
    }
}
