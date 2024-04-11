using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
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
        private readonly IUserItemsRepository<Movie> _userItemsRepository;

        public MoviesController(IMoviesRepository moviesRepository, 
            IUserRepository userRepository,
            IUserItemsRepository<Movie> userItemsRepository)
        {
            _moviesRepository = moviesRepository;
            _userRepository = userRepository;
            _userItemsRepository = userItemsRepository;
        }

        [HttpPost("AddMovieToUser/{movieId}")]
        public async Task<IActionResult> AddMovieForUser(ObjectId movieId)
        {
            var username = User.GetUsername();

            if (username == null) return BadRequest("User does not exist");

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var movie = await _moviesRepository.GetMovieByIdAsync(movieId);
            if (movie == null) return NotFound("Movie not found");

            if (user.AppUserMovie.Contains(movieId.ToString()) == true) return BadRequest("You have already added this movie to your list");

            await _userItemsRepository.AddItemToUser<Movie>(user, movieId);

            return Ok(user);
        }

        [HttpGet("GetMoviesFor/{username}")]
        public async Task<IActionResult> GetMoviesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfMovies = await _userItemsRepository.GetItemForUser<Movie>(user.Id);
            return Ok(listOfMovies);
        }

        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetMovies([FromQuery] MovieParams movieParams)
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

            return await _userItemsRepository.IsItemAlreadyAdded(userId, movieId);
        }

        [HttpDelete("DeleteMovieFromUser/{movieId}")]
        public async Task<IActionResult> DeleteMovieForUser(ObjectId movieId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            var movie = await _moviesRepository.GetMovieByIdAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            await _userItemsRepository.DeleteItemFromUser<Movie>(user, movieId);

            return Ok();
        }
    }
}
