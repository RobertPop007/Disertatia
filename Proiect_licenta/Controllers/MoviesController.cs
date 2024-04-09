using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Disertatie_backend.Controllers
{
    public class MoviesController : BaseApiController
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IUserRepository _userRepository;

        public MoviesController(IMoviesRepository moviesRepository, IUserRepository userRepository)
        {
            _moviesRepository = moviesRepository;
            _userRepository = userRepository;
        }

        [HttpPost("AddMovie/{movieId}")]
        public async Task<ActionResult> AddMovieForUser(ObjectId movieId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var movie = await _moviesRepository.GetMovieByIdAsync(movieId);
            if (movie == null) return NotFound("Movie not found");

            if (user.AppUserMovie.Contains(movieId.ToString()) == true) return BadRequest("You have already added this movie to your list");

            await _moviesRepository.AddMovieToUser(user.Id, movie.Id);

            return Ok(user);
        }

        [HttpGet("GetMoviesFor/{username}")]
        public async Task<ActionResult> GetMoviesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfMovies = await _moviesRepository.GetUserMovies(user.Id);
            return Ok(listOfMovies);
        }

        [HttpGet("GetAllMovies")]
        public async Task<ActionResult> GetMovies([FromQuery] MovieParams movieParams)
        {
            var movies = await _moviesRepository.GetMoviesAsync(movieParams);
            return Ok(movies);
        }

        [HttpGet("{title}", Name = "GetMovie")]
        public async Task<ActionResult<Movie>> GetMovie(string title)
        {
            return await _moviesRepository.GetMovieByTitleAsync(title);
        }

        [HttpGet("MovieAlreadyAdded")]
        public async Task<bool> IsMovieAlreadyAdded(ObjectId movieId)
        {
            var userId = User.GetUserId();

            return await _moviesRepository.IsMovieAlreadyAdded(userId, movieId);
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovieForUser(ObjectId movieId)
        {
            var userId = User.GetUserId();

            var movie = await _moviesRepository.GetMovieByIdAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            await _moviesRepository.DeleteMovieForUser(userId, movieId);

            return Ok();
        }
    }
}
