using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Disertatie_backend.Controllers
{
    public class AnimeController : BaseApiController
    {
        private readonly IAnimeRepository _animesRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private static IMongoCollection<AppUserAnimeItem> _userAnimeCollection;
        private static IMongoCollection<AppUser> _userCollection;

        public AnimeController(DataContext context, IAnimeRepository animesRepository, IMapper mapper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _animesRepository = animesRepository;
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;

            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _userAnimeCollection = mongoDb.GetCollection<AppUserAnimeItem>("UserAnime");
            _userCollection = mongoDb.GetCollection<AppUser>("Users");
        }


        //facem cumva sa avem acele colectii numai in repo
        [HttpPost("AddAnime/{animeId}")]
        public async Task<ActionResult> AddAnimeForUser(int animeId)
        {
            var username = "rae";
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var anime = await _animesRepository.GetAnimeByIdAsync(animeId);
            if (anime == null) return NotFound("Anime not found");

            var appUserAnimeItem = new AppUserAnimeItem
            {
                AppUserId = user.Id,
                AnimeId = animeId
            };

            var alreadyAdded = await _userAnimeCollection.FindAsync(o => o.AppUserId == user.Id && o.AnimeId == animeId);

            if (alreadyAdded.Any() == true) return BadRequest("You have already added this anime to your list");

            await _userAnimeCollection.InsertOneAsync(appUserAnimeItem);

            if(user.AppUserAnime == null) user.AppUserAnime = new List<AppUserAnimeItem>();
            user.AppUserAnime.Add(appUserAnimeItem);

            await _userRepository.SaveAllAsync();

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
