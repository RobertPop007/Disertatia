using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;

namespace Disertatie_backend.Controllers
{
    public class MangaController : BaseApiController
    {
        private readonly IMangaRepository _mangasRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserItemsRepository<DatumManga> _userItemsRepository;

        public MangaController(IMangaRepository mangasRepository, 
            IUserRepository userRepository,
            IUserItemsRepository<DatumManga> userItemsRepository
            )
        {
            _mangasRepository = mangasRepository;
            _userRepository = userRepository;
            _userItemsRepository = userItemsRepository;
        }

        [HttpPost("AddMangaToUser/{mangaId}")]
        public async Task<IActionResult> AddMangaForUser(ObjectId mangaId)
        {
            var username = User.GetUsername();

            if (username == null) return BadRequest("User does not exist");

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var manga = await _mangasRepository.GetMangaByIdAsync(mangaId);
            if (manga == null) return NotFound("Manga not found");

            if (user.AppUserManga.Contains(manga.Id.ToString()) == true) return BadRequest("You have already added this anime to your list");

            await _userItemsRepository.AddItemToUser<DatumManga>(user, mangaId);

            return Ok(user);
        }

        [HttpGet("GetMangasFor/{username}")]
        public async Task<IActionResult> GetMangasForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfMangas = await _userItemsRepository.GetItemForUser<DatumManga>(user.Id);
            return Ok(listOfMangas);
        }

        [HttpGet("GetAllMangas")]
        public async Task<IActionResult> GetMangas([FromQuery] MangaParams mangaParams)
        {
            var mangas = await _mangasRepository.GetMangasAsync(mangaParams);

            return Ok(mangas);
        }

        [HttpGet("{title}", Name = "GetManga")]
        public async Task<ActionResult<DatumManga>> GetManga(string title)
        {
            return await _mangasRepository.GetMangaByFullTitleAsync(title);
        }

        [HttpGet("MangaAlreadyAdded")]
        public async Task<bool> IsMangaAlreadyAdded(ObjectId mangaId)
        {
            var userId = User.GetUserId();

            return await _userItemsRepository.IsItemAlreadyAdded(userId, mangaId);
        }

        [HttpDelete("DeleteMangaFrom/{mangaId}")]
        public async Task<IActionResult> DeleteMangaForUser(ObjectId mangaId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            var manga = await _mangasRepository.GetMangaByIdAsync(mangaId);
            if (manga == null)
            {
                return NotFound();
            }

            await _userItemsRepository.DeleteItemFromUser<Datum>(user, mangaId);

            return Ok();
        }
    }
}
