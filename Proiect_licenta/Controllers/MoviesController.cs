using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Disertatie_backend.Extensions;
using Disertatie_backend.Entities;
using Disertatie_backend.Helpers;

namespace Disertatie_backend.Controllers
{
    public class MoviesController : BaseApiController
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public MoviesController(DataContext context, IMoviesRepository moviesRepository, IMapper mapper, IUserRepository userRepository)
        {
            _moviesRepository = moviesRepository;
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("AddMovie/{movieId}")]
        public async Task<ActionResult> AddMovieForUser(string movieId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var movie = await _moviesRepository.GetMovieByIdAsync(movieId);
            if (movie == null) return NotFound("Movie not found");

            var appUserMovieItem = new AppUserMovieItem
            {
                AppUserId = user.Id,
                MovieId = movieId
            };

            var alreadyAdded = await _context.AppUserMovieItems.AnyAsync(o => o.AppUserId == user.Id && o.MovieId == movieId);

            if (alreadyAdded == true) return BadRequest("You have already added this movie to your list");

            await _context.AppUserMovieItems.AddAsync(appUserMovieItem);
            user.AppUserMovie.Add(appUserMovieItem);

            await _userRepository.SaveAllAsync();

            await _context.SaveChangesAsync();
            
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

            //Response.AddPaginationHeader(movies.CurrentPage, movies.PageSize, movies.TotalCount, movies.TotalPages);

            return Ok(movies);
        }

        [HttpGet("{title}", Name = "GetMovie")]
        public async Task<ActionResult<Movie>> GetMovie(string title)
        {
            return await _moviesRepository.GetMovieByTitleAsync(title);
        }

        [HttpGet("MovieAlreadyAdded")]
        public bool IsMovieAlreadyAdded(string movieId)
        {
            var userId = User.GetUserId();

            return _moviesRepository.IsMovieAlreadyAdded(userId, movieId);
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovieForUser(string movieId)
        {
            var userId = User.GetUserId();

            var movie = await _context.Movies.FindAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            _moviesRepository.DeleteMovieForUser(userId, movieId);

            if (await _moviesRepository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting the movie for this user");
        }
    }
}
