using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using Disertatie_backend.Entities;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using AutoMapper;
using System;

namespace Disertatie_backend.DatabaseContext
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMongoCollection<Movie> _moviesCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<Movie> _moviesCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string titleIndex = "Title_index";

        private readonly IMapper _mapper;

        public MoviesRepository(IMapper mapper, IMongoDBCollectionHelper<Movie> moviesCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _moviesCollectionHelper = moviesCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _moviesCollection = _moviesCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _moviesCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);

            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieCard>> GetMoviesAsync(MovieParams movieParams)
        {
            if (string.IsNullOrEmpty(movieParams.SearchedMovie) || string.IsNullOrWhiteSpace(value: movieParams.SearchedMovie)) return null;

            var filterByTitle = Builders<Movie>.Filter.Where(x => x.Title.Contains(movieParams.SearchedMovie)) |
                Builders<Movie>.Filter.Where(x => x.FullTitle.Contains(movieParams.SearchedMovie)) |
                Builders<Movie>.Filter.Where(x => x.OriginalTitle.Contains(movieParams.SearchedMovie));

            var query = await _moviesCollection.Find(filterByTitle).ToListAsync();

            var queryList = new List<MovieCard>();

            foreach (var document in query)
            {
                queryList.Add(_mapper.Map<MovieCard>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = movieParams.OrderBy switch
            {
                "fulltitle" => mappedQuery.OrderBy(u => u.FullTitle).OrderByDescending(u => u.Year),
                "imdbRating" => mappedQuery.OrderByDescending(u => u.ImDbRating),
                _ => mappedQuery.OrderByDescending(u => u.Year)

            };

            return mappedQuery;
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

        public async Task<IEnumerable<Movie>> GetUserMovies(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfMoviesForUser = new List<Movie>();

            foreach (var movieId in user.AppUserMovie)
            {
                var movie = await GetMovieByIdAsync(new ObjectId(movieId));

                if (movie != null) listOfMoviesForUser.Add(movie);
            }

            return listOfMoviesForUser;
        }

        public async Task<bool> IsMovieAlreadyAdded(Guid userId, ObjectId movieId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isMovieAlreadyAdded = user.AppUserMovie.Contains(movieId.ToString());
            if (isMovieAlreadyAdded == true) return true;
            return false;
        }

        public async Task DeleteMovieForUser(Guid userId, ObjectId movieId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserMovie, movieId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddMovieToUser(Guid userId, ObjectId movieId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserMovie, movieId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
        }
    }
}
