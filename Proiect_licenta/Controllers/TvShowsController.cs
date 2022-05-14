using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.Entities;
using Proiect_licenta.Entities.TvShows;
using Proiect_licenta.Extensions;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Threading.Tasks;

namespace Proiect_licenta.Controllers
{
    public class TvShowsController : BaseApiController
    {
        private readonly ITvShowsRepository _tvShowsRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public TvShowsController(DataContext context, ITvShowsRepository tvShowsRepository, IMapper mapper, IUserRepository userRepository)
        {
            _tvShowsRepository = tvShowsRepository;
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("AddTvShow/{tvShowId}")]
        public async Task<ActionResult> AddMovieForUser(string tvShowId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(tvShowId);
            if (tvShow == null) return NotFound("TvShow not found");

            var appUserTvShowItem = new AppUserTvShowItem
            {
                AppUserId = user.Id,
                TvShowId = tvShowId
            };

            var alreadyAdded = await _context.AppUserTvShowItems.AnyAsync(o => o.AppUserId == user.Id && o.TvShowId == tvShowId);

            if (alreadyAdded == true) return BadRequest("You have already added this tv show to your list");

            await _context.AppUserTvShowItems.AddAsync(appUserTvShowItem);
            user.AppUserTvShow.Add(appUserTvShowItem);

            await _userRepository.SaveAllAsync();

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet("GetTvShowsFor/{username}")]
        public async Task<ActionResult> GetTvShowsForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfTvShows = await _tvShowsRepository.GetUserTvShows(user.Id);
            return Ok(listOfTvShows);
        }

        [HttpGet("GetAllTvShows")]
        public async Task<ActionResult> GetMovies([FromQuery] TvShowParams tvShowParams)
        {
            var tvShows = await _tvShowsRepository.GetTvShowsAsync(tvShowParams);

            //Response.AddPaginationHeader(movies.CurrentPage, movies.PageSize, movies.TotalCount, movies.TotalPages);

            return Ok(tvShows);
        }

        [HttpGet("{fullTitle}", Name = "GetTvShow")]
        public async Task<ActionResult<TvShow>> GetTvShow(string fullTitle)
        {
            return await _tvShowsRepository.GetTvShowByFullTitleAsync(fullTitle);
        }

        [HttpGet("TvShowAlreadyAdded")]
        public bool IsTvShowAlreadyAdded(string tvShowId)
        {
            var userId = User.GetUserId();

            return _tvShowsRepository.IsTvShowAlreadyAdded(userId, tvShowId);
        }

        [HttpDelete("{tvShowId}")]
        public async Task<IActionResult> DeleteTvShowForUser(string tvShowId)
        {
            var userId = User.GetUserId();

            var tvShow = await _context.TrueTvShow.FindAsync(tvShowId);
            if (tvShow == null)
            {
                return NotFound();
            }

            _tvShowsRepository.DeleteShowForUser(userId, tvShowId);

            if (await _tvShowsRepository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting the tv show for this user");
        }
    }
}
