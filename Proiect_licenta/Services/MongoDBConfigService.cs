using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Disertatie_backend.Services
{
    public class MongoDBConfigService<T>
    {
        private IMongoCollection<T> _mongoCollection;

        public IMongoCollection<T> GetCollectionContext(IOptions<DatabaseSettings> databaseSettings, string collectionName)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

            _mongoCollection = mongoDb.GetCollection<T>(collectionName);

            return _mongoCollection;
        }
    }
}
