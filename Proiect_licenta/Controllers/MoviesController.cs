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

        [HttpGet("Top250Movies")]
        public async Task<ActionResult<IEnumerable<MovieItem>>> GetTop250Movies()
        {
            var top250Movies = _moviesRepository.Get();

            return Ok(top250Movies);
        }

        [HttpPost("AddMovie/{movieId}")]
        public async Task<ActionResult> AddMovieForUser([FromRoute] string movieId)
        {
            var username = User.GetUsername();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var movie = _moviesRepository.Get(movieId);
            if (movie == null) return NotFound("Movie not found");

            user.Movies.Add(movie);
            _context.Users.Update(user);

            return Ok(user);
        }
    }
}
