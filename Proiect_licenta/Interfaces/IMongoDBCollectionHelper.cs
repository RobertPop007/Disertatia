using System.Linq.Expressions;
using System;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Disertatie_backend.Interfaces
{
    public interface IMongoDBCollectionHelper<T> where T : class
    {
        void CreateIndexAscending(Expression<Func<T, object>> field, string indexName);
        IMongoCollection<T> CreateCollection(DatabaseSettings databaseSettings);
    }
}
