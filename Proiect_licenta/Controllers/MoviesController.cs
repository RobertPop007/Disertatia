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

namespace Proiect_licenta.Controllers
{
    //[Authorize]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IBaseRepository<MovieItem, DataContext> _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesController(IServiceProvider serviceProvider, IMapper mapper)
        {
            _moviesRepository = serviceProvider.GetService<IBaseRepository<MovieItem, DataContext>>();
            _mapper = mapper;
        }

        [HttpGet("Top250Movies")]
        public async Task<ActionResult<IEnumerable<MovieGeneralInfo>>> GetTop250Movies()
        {
            var top250Movies = _moviesRepository.Get();

            return Ok(top250Movies);
        }
    }
}
