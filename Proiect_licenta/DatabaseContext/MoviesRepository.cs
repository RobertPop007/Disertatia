using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Entities.Movies;
using Proiect_licenta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.DatabaseContext
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MoviesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieItem>> GetMoviesAsync()
        {
            return await _context.Top250Movies.ToListAsync();
        }
    }
}
