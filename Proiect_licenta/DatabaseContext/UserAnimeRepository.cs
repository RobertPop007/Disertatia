using Disertatie_backend.Configurations;
using Disertatie_backend.Entities;
using Disertatie_backend.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Disertatie_backend.DatabaseContext
{
    public class UserAnimeRepository : IUserAnimeRepository
    {
        private readonly IMongoCollection<AppUserAnimeItem> _userAnimeCollection;
        private readonly IMongoDBCollectionHelper<AppUserAnimeItem> _animeUserCollectionHelper;
        private readonly string userIdIndex = "UserId_Index";
        private readonly string animeIdIndex = "AnimeId_Index";

        public UserAnimeRepository(IMongoDBCollectionHelper<AppUserAnimeItem> animeUserCollectionHelper, IOptions<DatabaseSettings> databaseSettings)
        {
            _animeUserCollectionHelper = animeUserCollectionHelper;
            _userAnimeCollection = _animeUserCollectionHelper.CreateCollection(databaseSettings);
        }

        public async Task<AppUserAnimeItem> GetItemById(ObjectId userId, ObjectId animeId)
        {
            _animeUserCollectionHelper.CreateIndexAscending(u => u.AppUserId, userIdIndex);
            _animeUserCollectionHelper.CreateIndexAscending(u => u.AnimeId, animeIdIndex);

            var filterByIds = Builders<AppUserAnimeItem>.Filter.Eq(p => p.AppUserId, userId)
                & Builders<AppUserAnimeItem>.Filter.Eq(p => p.AnimeId, animeId);

            var result = await _userAnimeCollection.Find(filterByIds).FirstOrDefaultAsync();
            _animeUserCollectionHelper.DropIndex(userIdIndex);
            _animeUserCollectionHelper.DropIndex(animeIdIndex);

            return result;
        }

        public async Task AddItem(AppUserAnimeItem appUserAnimeItem)
        {
            await _userAnimeCollection.InsertOneAsync(appUserAnimeItem);
        }
    }
}
