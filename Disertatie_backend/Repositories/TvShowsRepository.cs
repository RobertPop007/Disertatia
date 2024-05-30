using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
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
    public class TvShowsRepository : ITvShowsRepository
    {
        private readonly IMongoCollection<TvShow> _tvshowsCollection;
        private readonly IMongoDBCollectionHelper<TvShow> _tvshowsCollectionHelper;
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public TvShowsRepository(IMapper mapper,
            IMongoDBCollectionHelper<TvShow> tvshowsCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _tvshowsCollectionHelper = tvshowsCollectionHelper;
            _tvshowsCollection = _tvshowsCollectionHelper.CreateCollection(_databaseSettings);

            _mapper = mapper;
        }

        public async Task AddReviewAsync(ObjectId id, Review review)
        {
            var filter = Builders<TvShow>.Filter.Eq(x => x.Id, id);
            var update = Builders<TvShow>.Update.Push(x => x.ReviewsIds, review.ReviewId);

            await _tvshowsCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, Guid reviewId)
        {
            var filter = Builders<TvShow>.Filter.Eq(x => x.Id, id);
            var update = Builders<TvShow>.Update.Pull(x => x.ReviewsIds, reviewId);

            await _tvshowsCollection.UpdateOneAsync(filter, update);
        }

        public async Task<TvShow> GetTvShowByFullTitleAsync(string title)
        {
            var filterByName = Builders<TvShow>.Filter.Eq(p => p.Name, title);
            return await _tvshowsCollection.Find(filterByName).FirstOrDefaultAsync();
        }

        public async Task<TvShow> GetTvShowByIdAsync(ObjectId id)
        {
            var filterById = Builders<TvShow>.Filter.Eq(p => p.Id, id);
            return await _tvshowsCollection.Find(filterById).FirstOrDefaultAsync();
        }

        public async Task<PagedList<TvShowCard>> GetTvShowsAsync(TvShowParams tvShowParams)
        {
            var query = Enumerable.Empty<TvShow>().AsQueryable();
            var filterByTitle = Builders<TvShow>.Filter.Empty;
            var filterByFullTitle = Builders<TvShow>.Filter.Empty;
            var filterByOriginalTitle = Builders<TvShow>.Filter.Empty;

            if (!(string.IsNullOrEmpty(tvShowParams.SearchedTvShow) || string.IsNullOrWhiteSpace(tvShowParams.SearchedTvShow)))
            {
                filterByTitle = Builders<TvShow>.Filter.Regex(x => x.Name, new BsonRegularExpression(tvShowParams.SearchedTvShow, "i"));
                filterByFullTitle = Builders<TvShow>.Filter.Regex(x => x.OriginalName, new BsonRegularExpression(tvShowParams.SearchedTvShow, "i"));

                filterByTitle = filterByTitle & filterByFullTitle & filterByOriginalTitle;

                query = _tvshowsCollection.Find(filterByTitle).ToList().AsQueryable();
            }
            else
                query = _tvshowsCollection.AsQueryable().AsQueryable();

            query = tvShowParams.OrderBy switch
            {
                "name" => query.OrderBy(u => u.Name).OrderByDescending(u => u.FirstAirDate),
                "voteAverage" => query.OrderByDescending(u => u.VoteAverage),
                _ => query.OrderByDescending(u => u.Popularity)

            };

            return await PagedList<TvShowCard>.CreateAsync(query.ProjectTo<TvShowCard>(_mapper.ConfigurationProvider).AsNoTracking(),
                 tvShowParams.PageNumber, tvShowParams.PageSize);
        }
    }
}
