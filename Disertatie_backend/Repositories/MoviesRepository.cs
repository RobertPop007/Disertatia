using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using AutoMapper;
using Disertatie_backend.DTO;

namespace Disertatie_backend.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMongoCollection<Movie> _moviesCollection;
        private readonly IMongoDBCollectionHelper<Movie> _moviesCollectionHelper;
        private readonly string titleIndex = "Title_index";
        private readonly string titleOriginalIndex = "TitleOriginal_index";
        private readonly string titleFullIndex = "TitleFull_index";
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public MoviesRepository(IMapper mapper,
            IMongoDBCollectionHelper<Movie> moviesCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _moviesCollectionHelper = moviesCollectionHelper;
            _moviesCollection = _moviesCollectionHelper.CreateCollection(_databaseSettings);

            _moviesCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);
            _moviesCollectionHelper.CreateIndexAscending(u => u.FullTitle, titleFullIndex);
            _moviesCollectionHelper.CreateIndexAscending(u => u.OriginalTitle, titleOriginalIndex);

            _mapper = mapper;
        }

        public async Task AddReviewAsync(ObjectId id, ReviewDto reviewDto)
        {
            var filter = Builders<Movie>.Filter.Eq(x => x.Id, id);
            var update = Builders<Movie>.Update.Push(x => x.ReviewsIds, reviewDto.ReviewId);

            await _moviesCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, ReviewDto reviewDto)
        {
            var filter = Builders<Movie>.Filter.Eq(x => x.Id, id);
            var update = Builders<Movie>.Update.Pull(x => x.ReviewsIds, reviewDto.ReviewId);

            await _moviesCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<MovieCard>> GetMoviesAsync(MovieParams movieParams)
        {
            var filterByTitle = Builders<Movie>.Filter.Empty;
            var filterByFullTitle = Builders<Movie>.Filter.Empty;
            var filterByOriginalTitle = Builders<Movie>.Filter.Empty;

            if (!(string.IsNullOrEmpty(movieParams.SearchedMovie) || string.IsNullOrWhiteSpace(movieParams.SearchedMovie)))
            {
                filterByTitle = Builders<Movie>.Filter.Regex(x => x.Title, new BsonRegularExpression(movieParams.SearchedMovie, "i"));
                filterByFullTitle = Builders<Movie>.Filter.Regex(x => x.OriginalTitle, new BsonRegularExpression(movieParams.SearchedMovie, "i"));
                filterByOriginalTitle = Builders<Movie>.Filter.Regex(x => x.FullTitle, new BsonRegularExpression(movieParams.SearchedMovie, "i"));

                filterByTitle = filterByTitle & filterByFullTitle & filterByOriginalTitle;
            }

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
    }
}
