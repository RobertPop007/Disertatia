using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Entities.Movies;
using Proiect_licenta.Helpers;
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

        public async Task<PagedList<MovieItem>> GetMoviesAsync(MovieParams movieParams)
        {
            var query = _context.Top250Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(movieParams.SearchedMovie))
                query = query.Where(u => u.FullTitle.Contains(movieParams.SearchedMovie));

            query = movieParams.OrderBy switch
            {
                "fulltitle" => query.OrderBy(u => u.FullTitle).OrderBy(u => u.Year),
                "imdbRating" => query.OrderByDescending(u => u.ImDbRating),
                _ => query.OrderBy(u => u.Id)

            };

            return await PagedList<MovieItem>.CreateAsync(query.ProjectTo<MovieItem>(_mapper.ConfigurationProvider).AsNoTracking(),
                movieParams.PageNumber, movieParams.PageSize);
        }

        public async Task<MovieItem> GetMovieByIdAsync(string id)
        {
            return await _context.Top250Movies.FindAsync(id);
        }
        public async Task<MovieItem> GetMovieByFullTitleAsync(string fullTitle)
        {
            return await _context.Top250Movies
                .SingleOrDefaultAsync(x => x.FullTitle == fullTitle);
        }
    }
}
