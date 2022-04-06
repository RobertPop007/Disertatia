using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.DTO.Movies;
using Proiect_licenta.Entities.Movies;
using Proiect_licenta.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Extensions;
using Proiect_licenta.Entities;

namespace Proiect_licenta.Controllers
{
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly IBaseRepository<MovieItem, DataContext> _moviesRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public MoviesController(DataContext context, IServiceProvider serviceProvider, IMapper mapper, IUserRepository userRepository)
        {
            _moviesRepository = serviceProvider.GetService<IBaseRepository<MovieItem, DataContext>>();
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("AddMovie/{movieId}")]
        public async Task<ActionResult> AddMovieForUser([FromRoute] string movieId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var movie = _moviesRepository.Get(movieId);
            if (movie == null) return NotFound("Movie not found");

            var appUserMovieItem = new AppUserMovieItem
            {
                AppUserId = user.Id,
                MovieItemId = movieId
            };

            await _context.AppUserMovieItems.AddAsync(appUserMovieItem);
            user.AppUserMovieItems.Add(appUserMovieItem);

            await _userRepository.SaveAllAsync();

            await _context.SaveChangesAsync();
            
            return Ok(user);
        }

        [HttpGet("GetMoviesFor/{username}")]
        public async Task<ActionResult> GetMoviesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var moviesIds = _context.AppUserMovieItems.Select(t => t.MovieItemId).ToList();
            var movies = new List<MovieItem>();

            foreach (var movieId in moviesIds)
            {
                var movie = _moviesRepository.Get(movieId);
                movies.Add(movie);
            }

            return Ok(movies);
        }
    }
}
