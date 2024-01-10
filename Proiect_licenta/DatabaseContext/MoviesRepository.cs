using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Entities.Movies;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

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

        public async Task<List<Movie>> GetMoviesAsync(MovieParams movieParams)
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(movieParams.SearchedMovie))
                query = query.Where(u => u.FullTitle.Contains(movieParams.SearchedMovie));

            query = movieParams.OrderBy switch
            {
                "fulltitle" => query.OrderBy(u => u.FullTitle).OrderBy(u => u.Year),
                "imdbRating" => query.OrderByDescending(u => u.ImDbRating),
                _ => query.OrderByDescending(u => u.Year)

            };

            return await query.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(string id)
        {
            return await _context.Movies.FindAsync(id);
        }
        public async Task<Movie> GetMovieByFullTitleAsync(string fullTitle)
        {
            return await _context.Movies
                .Where(t => t.FullTitle == fullTitle)
                .IncludeOptimized(o => o.DirectorList)
                .IncludeOptimized(o => o.WriterList)
                .IncludeOptimized(o => o.ActorList)
                .IncludeOptimized(o => o.StarList)
                .IncludeOptimized(o => o.GenreList)
                .IncludeOptimized(o => o.CompanyList)
                .IncludeOptimized(o => o.CountryList)
                .IncludeOptimized(o => o.LanguageList)
                .IncludeOptimized(o => o.Ratings)
                .IncludeOptimized(o => o.Wikipedia)
                .IncludeOptimized(o => o.Images)
                .IncludeOptimized(o => o.Trailer)
                .IncludeOptimized(o => o.BoxOffice)
                .IncludeOptimized(o => o.Similars)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Movie>> GetUserMovies(int userId)
        {
            var listOfMoviesIdForUser = _context.AppUserMovieItems.Where(o => o.AppUserId == userId).Select(o => o.MovieId).AsEnumerable();

            var listOfMoviesForUser = new List<Movie>();

            foreach (var movieId in listOfMoviesIdForUser)
            {
                var movie = await _context.Movies.FindAsync(movieId);

                if (movie != null) listOfMoviesForUser.Add(movie);
            }

            return listOfMoviesForUser;
        }

        public bool IsMovieAlreadyAdded(int userId, string movieId)
        {
            var listOfMoviesIdForUser = _context.AppUserMovieItems.Where(o => o.AppUserId == userId).Select(o => o.MovieId).AsEnumerable();

            var isMovieAlreadyAdded = listOfMoviesIdForUser.Contains(movieId);
            if (isMovieAlreadyAdded == true) return true;
            return false;
        }

        public void DeleteMovieForUser(int userId, string movieId)
        {
            var appUserMovieItem = _context.AppUserMovieItems.FirstOrDefault(o => o.AppUserId == userId && o.MovieId == movieId);
            _context.AppUserMovieItems.Remove(appUserMovieItem);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
