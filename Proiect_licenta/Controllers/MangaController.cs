using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Disertatie_backend.Controllers
{
    public class MangaController : BaseApiController
    {
        private readonly IMangaRepository _mangasRepository;
        private readonly IUserRepository _userRepository;

        public MangaController(IMangaRepository mangasRepository, IUserRepository userRepository)
        {
            _mangasRepository = mangasRepository;
            _userRepository = userRepository;
        }

        [HttpPost("AddManga/{mangaId}")]
        public async Task<ActionResult> AddMangaForUser(ObjectId mangaId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var manga = await _mangasRepository.GetMangaByIdAsync(mangaId);
            if (manga == null) return NotFound("Manga not found");

            if (user.AppUserManga.Contains(manga.Id) == true) return BadRequest("You have already added this anime to your list");

            await _mangasRepository.AddMangaToUser(user.Id, manga.Id);

            return Ok(user);
        }

        [HttpGet("GetMangasFor/{username}")]
        public async Task<ActionResult> GetMangasForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfMangas = await _mangasRepository.GetUserMangas(user.Id);
            return Ok(listOfMangas);
        }

        [HttpGet("GetAllMangas")]
        public async Task<ActionResult> GetMangas([FromQuery] MangaParams mangaParams)
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

            return await _mangasRepository.IsMangaAlreadyAdded(userId, mangaId);
        }

        [HttpDelete("{mangaId}")]
        public async Task<IActionResult> DeleteMangaForUser(ObjectId mangaId)
        {
            var userId = User.GetUserId();

            var manga = await _mangasRepository.GetMangaByIdAsync(mangaId);
            if (manga == null)
            {
                return NotFound();
            }

            await _mangasRepository.DeleteMangaForUser(userId, mangaId);

            return Ok();
        }
    }
}
