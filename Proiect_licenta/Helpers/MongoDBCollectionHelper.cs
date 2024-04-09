using Disertatie_backend.Configurations;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Disertatie_backend.Helpers
{
    public class MongoDBCollectionHelper<T> : IMongoDBCollectionHelper<T> where T : class
    {
        public IMongoCollection<T> _collection;
        IDictionary<Type, string> mappedClasses = new Dictionary<Type, string>()
        {
            {typeof(AppUser), "UsersCollection" },
            {typeof(AppRole), "RolesCollection" },
            {typeof(Datum), "AnimeCollection" },
            {typeof(DatumManga), "MangaCollection" },
            {typeof(Movie), "MoviesCollection" },
            {typeof(TvShow), "TVShowsCollection" },
            {typeof(Game), "GamesCollection" },
            {typeof(AppUserAnimeItem), "UserAnimeCollection" },
            {typeof(AppUserMangaItem), "UserMangaCollection" },
            {typeof(AppUserMovieItem), "UserMoviesCollection" },
            {typeof(AppUserTvShowItem), "UserTVShowsCollection" },
            {typeof(AppUserGameItem), "UserGamesCollection" }
        };

        public IMongoCollection<T> CreateCollection(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoDbClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoDbClient.GetDatabase(databaseSettings.Value.DatabaseName);
            var collectionName = mappedClasses[typeof(T)];
            _collection = mongoDb.GetCollection<T>(databaseSettings.Value.CollectionList[collectionName]);

            return _collection;
        }

        public void CreateIndexAscending(Expression<Func<T, object>> field, string indexName)
        {
            var indexKey = Builders<T>.IndexKeys.Ascending(field);
            var indexOptions = new CreateIndexOptions { Name = indexName };
            _collection.Indexes.CreateOne(new CreateIndexModel<T>(indexKey, indexOptions));
        }
        public void CreateIndexDescending(Expression<Func<T, object>> field, string indexName)
        {
            var indexKey = Builders<T>.IndexKeys.Descending(field);
            var indexOptions = new CreateIndexOptions { Name = indexName };
            _collection.Indexes.CreateOne(new CreateIndexModel<T>(indexKey, indexOptions));
        }

        public void DropIndex(string indexName)
        {
            _collection.Indexes.DropOne(indexName);
        }
    }
}


