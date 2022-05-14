using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.Entities;
using Proiect_licenta.Entities.Manga;
using Proiect_licenta.Extensions;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Threading.Tasks;

namespace Proiect_licenta.Controllers
{
    public class MangaController : BaseApiController
    {
        private readonly IMangaRepository _mangasRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public MangaController(DataContext context, IMangaRepository mangasRepository, IMapper mapper, IUserRepository userRepository)
        {
            _mangasRepository = mangasRepository;
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("AddManga/{mangaId}")]
        public async Task<ActionResult> AddMangaForUser(int mangaId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var manga = await _mangasRepository.GetMangaByIdAsync(mangaId);
            if (manga == null) return NotFound("Manga not found");

            var appUsermangaItem = new AppUserMangaItem
            {
                AppUserId = user.Id,
                MangaId = mangaId
            };

            var alreadyAdded = await _context.AppUserMangaItems.AnyAsync(o => o.AppUserId == user.Id && o.MangaId == mangaId);

            if (alreadyAdded == true) return BadRequest("You have already added this manga to your list");

            await _context.AppUserMangaItems.AddAsync(appUsermangaItem);
            user.AppUserManga.Add(appUsermangaItem);

            await _userRepository.SaveAllAsync();

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet("GetMangasFor/{username}")]
        public async Task<ActionResult> GetMangasForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfMangas = await _mangasRepository.GetUserMangas(user.Id);
            return Ok(listOfMangas);
        }

        [HttpGet("GetAllmangas")]
        public async Task<ActionResult> Getmangas([FromQuery] MangaParams mangaParams)
        {
            var mangas = await _mangasRepository.GetMangasAsync(mangaParams);

            //Response.AddPaginationHeader(mangas.CurrentPage, mangas.PageSize, mangas.TotalCount, mangas.TotalPages);

            return Ok(mangas);
        }

        [HttpGet("{fullTitle}", Name = "Getmanga")]
        public async Task<ActionResult<DatumManga>> Getmanga(string fullTitle)
        {
            return await _mangasRepository.GetMangaByFullTitleAsync(fullTitle);
        }

        [HttpGet("MangaAlreadyAdded")]
        public bool IsMangaAlreadyAdded(int mangaId)
        {
            var userId = User.GetUserId();

            return _mangasRepository.IsMangaAlreadyAdded(userId, mangaId);
        }

        [HttpDelete("{mangaId}")]
        public async Task<IActionResult> DeletemangaForUser(int mangaId)
        {
            var userId = User.GetUserId();

            var manga = await _context.Manga.FindAsync(mangaId);
            if (manga == null)
            {
                return NotFound();
            }

            _mangasRepository.DeleteMangaForUser(userId, mangaId);

            if (await _mangasRepository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting the manga for this user");
        }
    }
}
