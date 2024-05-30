using AutoMapper;
using AutoMapper.QueryableExtensions;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO.Game;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.Repositories
{
    public class GameRepository : IGamesRepository
    {
        private readonly IMongoCollection<Game> _gamesCollection;
        private readonly IMongoDBCollectionHelper<Game> _gamesCollectionHelper;
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public GameRepository(IMapper mapper,
            IMongoDBCollectionHelper<Game> gamesCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _gamesCollectionHelper = gamesCollectionHelper;
            _gamesCollection = _gamesCollectionHelper.CreateCollection(_databaseSettings);

            _mapper = mapper;
        }
        public async Task AddReviewAsync(ObjectId id, Review review)
        {
            var filter = Builders<Game>.Filter.Eq(x => x.Id, id);
            var update = Builders<Game>.Update.Push(x => x.ReviewsIds, review.ReviewId);

            await _gamesCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, Guid reviewId)
        {
            var filter = Builders<Game>.Filter.Eq(x => x.Id, id);
            var update = Builders<Game>.Update.Pull(x => x.ReviewsIds, reviewId);

            await _gamesCollection.UpdateOneAsync(filter, update);
        }

        public async Task<Game> GetGameByNameAsync(string name)
        {
            var filterByName = Builders<Game>.Filter.Eq(p => p.Name, name);
            return await _gamesCollection.Find(filterByName).FirstOrDefaultAsync();
        }

        public async Task<Game> GetGameByIdAsync(ObjectId id)
        {
            var filterById = Builders<Game>.Filter.Eq(p => p.Id, id);
            return await _gamesCollection.Find(filterById).FirstOrDefaultAsync();
        }

        public async Task<PagedList<GameCard>> GetGamesAsync(GameParams gameParams)
        {
            var query = Enumerable.Empty<Game>().AsQueryable();
            var filterByName = Builders<Game>.Filter.Empty;

            if (!(string.IsNullOrEmpty(gameParams.SearchedGame) || string.IsNullOrWhiteSpace(gameParams.SearchedGame)))
            {
                filterByName = Builders<Game>.Filter.Regex(x => x.Name, new BsonRegularExpression(gameParams.SearchedGame, "i"));

                query = _gamesCollection.Find(filterByName).ToList().AsQueryable();
            }
            else
                query = _gamesCollection.AsQueryable().AsQueryable();

            query = gameParams.OrderBy switch
            {
                "name" => query.OrderBy(u => u.Name).OrderByDescending(u => u.Released),
                "released" => query.OrderByDescending(u => u.Released),
                "rating" => query.OrderByDescending(u => u.Rating),
                _ => query.OrderByDescending(u => u.RatingsCount)

            };

            return await PagedList<GameCard>.CreateAsync(query.ProjectTo<GameCard>(_mapper.ConfigurationProvider).AsNoTracking(),
                gameParams.PageNumber, gameParams.PageSize);
        }
    }
}
