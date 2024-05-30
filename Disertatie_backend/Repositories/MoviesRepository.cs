using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using AutoMapper;
using Disertatie_backend.Entities.User;
using System;
using AutoMapper.QueryableExtensions;

namespace Disertatie_backend.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMongoCollection<Movie> _moviesCollection;
        private readonly IMongoDBCollectionHelper<Movie> _moviesCollectionHelper;
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public MoviesRepository(IMapper mapper,
            IMongoDBCollectionHelper<Movie> moviesCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _moviesCollectionHelper = moviesCollectionHelper;
            _moviesCollection = _moviesCollectionHelper.CreateCollection(_databaseSettings);

            _mapper = mapper;
        }

        public async Task AddReviewAsync(ObjectId id, Review review)
        {
            var filter = Builders<Movie>.Filter.Eq(x => x.Id, id);
            var update = Builders<Movie>.Update.Push(x => x.ReviewsIds, review.ReviewId);

            await _moviesCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, Guid reviewId)
        {
            var filter = Builders<Movie>.Filter.Eq(x => x.Id, id);
            var update = Builders<Movie>.Update.Pull(x => x.ReviewsIds, reviewId);

            await _moviesCollection.UpdateOneAsync(filter, update);
        }

        public async Task<PagedList<MovieCard>> GetMoviesAsync(MovieParams movieParams)
        {
            var query = Enumerable.Empty<Movie>().AsQueryable();
            var filterByTitle = Builders<Movie>.Filter.Empty;
            var filterByFullTitle = Builders<Movie>.Filter.Empty;
            var filterByOriginalTitle = Builders<Movie>.Filter.Empty;

            if (!(string.IsNullOrEmpty(movieParams.SearchedMovie) || string.IsNullOrWhiteSpace(movieParams.SearchedMovie)))
            {
                filterByTitle = Builders<Movie>.Filter.Regex(x => x.Title, new BsonRegularExpression(movieParams.SearchedMovie, "i"));
                filterByFullTitle = Builders<Movie>.Filter.Regex(x => x.OriginalTitle, new BsonRegularExpression(movieParams.SearchedMovie, "i"));

                filterByTitle = filterByTitle & filterByFullTitle & filterByOriginalTitle;

                query = _moviesCollection.Find(filterByTitle).ToList().AsQueryable();
            }
            else
                query = _moviesCollection.AsQueryable().AsQueryable();


            query = movieParams.OrderBy switch
            {
                "title" => query.OrderBy(u => u.Title).OrderByDescending(u => u.ReleaseDate),
                "voteAverage" => query.OrderByDescending(u => u.VoteAverage),
                _ => query.OrderByDescending(u => u.Popularity)

            };

            return await PagedList<MovieCard>.CreateAsync(query.ProjectTo<MovieCard>(_mapper.ConfigurationProvider).AsNoTracking(),
                movieParams.PageNumber, pageSize: movieParams.PageSize);
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
