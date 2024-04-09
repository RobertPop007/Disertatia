using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Disertatie_backend.Controllers
{
    public class TvShowsController : BaseApiController
    {
        private readonly ITvShowsRepository _tvShowsRepository;
        private readonly IUserRepository _userRepository;

        public TvShowsController(ITvShowsRepository tvShowsRepository, IUserRepository userRepository)
        {
            _tvShowsRepository = tvShowsRepository;
            _userRepository = userRepository;
        }

        [HttpPost("AddTvShow/{tvShowId}")]
        public async Task<ActionResult> AddMovieForUser(ObjectId tvShowId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(tvShowId);
            if (tvShow == null) return NotFound("TvShow not found");

            if (user.AppUserTvShow.Contains(tvShowId.ToString()) == true) return BadRequest("You have already added this tv show to your list");

            await _tvShowsRepository.AddTvShowToUser(user.Id, tvShow.Id);

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
            return Ok(tvShows);
        }

        [HttpGet("{title}", Name = "GetTvShow")]
        public async Task<ActionResult<TvShow>> GetTvShow(string title)
        {
            return await _tvShowsRepository.GetTvShowByFullTitleAsync(title);
        }

        [HttpGet("TvShowAlreadyAdded")]
        public async Task<bool> IsTvShowAlreadyAdded(ObjectId tvShowId)
        {
            var userId = User.GetUserId();

            return await _tvShowsRepository.IsTvShowAlreadyAdded(userId, tvShowId);
        }

        [HttpDelete("{tvShowId}")]
        public async Task<IActionResult> DeleteTvShowForUser(ObjectId tvShowId)
        {
            var userId = User.GetUserId();

            var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(tvShowId);
            if (tvShow == null)
            {
                return NotFound();
            }

            await _tvShowsRepository.DeleteShowForUser(userId, tvShowId);

            return Ok();
        }
    }
}
