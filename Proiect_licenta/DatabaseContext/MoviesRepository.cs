using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using MongoDB.Bson;
using Disertatie_backend.Entities;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;

namespace Disertatie_backend.DatabaseContext
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DataContext _context;
        private readonly IMongoCollection<Movie> _moviesCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<Movie> _moviesCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string titleIndex = "Title_index";

        public MoviesRepository(DataContext context, IMongoDBCollectionHelper<Movie> moviesCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _moviesCollectionHelper = moviesCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _moviesCollection = _moviesCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _moviesCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);
        }

        //aici umblam cand vedem si partea de frontend, să stim ca intoarcem ce trebuie
        public async Task<List<MovieCard>> GetMoviesAsync(MovieParams movieParams)
        {
            var query = _context.Movies
                .Select(movie => new MovieCard
                {
                    Title = movie.Title,
                    FullTitle = movie.FullTitle,
                    Id = movie.MovieId,
                    ImDbRating = movie.ImDbRating,
                    Image = movie.Image,
                    Year = movie.Year
                })
                .AsQueryable();


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

        public async Task<Movie> GetMovieByIdAsync(ObjectId id)
        {
            var filterById = Builders<Movie>.Filter.Eq(p => p.Id, id);
            return await _moviesCollection.Find(filterById).FirstOrDefaultAsync();
        }
        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            var filterByName = Builders<Movie>.Filter.Eq(p => p.Title, title);
            return await _moviesCollection.Find(filterByName).FirstOrDefaultAsync();
        }

        public async Task<List<Movie>> GetUserMovies(ObjectId userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfMoviesForUser = new List<Movie>();

            foreach (var movieId in user.AppUserMovie)
            {
                var movie = await GetMovieByIdAsync(movieId);

                if (movie != null) listOfMoviesForUser.Add(movie);
            }

            return listOfMoviesForUser;
        }

        public async Task<bool> IsMovieAlreadyAdded(ObjectId userId, ObjectId movieId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isMovieAlreadyAdded = user.AppUserMovie.Contains(movieId);
            if (isMovieAlreadyAdded == true) return true;
            return false;
        }

        public async Task DeleteMovieForUser(ObjectId userId, ObjectId movieId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserMovie, movieId);
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddMovieToUser(ObjectId userId, ObjectId movieId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserMovie, movieId);
            await _userCollection.UpdateOneAsync(filter, update);
        }
    }
}
