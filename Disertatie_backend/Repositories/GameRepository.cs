﻿using AutoMapper;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO;
using Disertatie_backend.DTO.Game;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.Repositories
{
    public class GameRepository : IGamesRepository
    {
        private readonly IMongoCollection<Game> _gamesCollection;
        private readonly IMongoDBCollectionHelper<Game> _gamesCollectionHelper;
        private readonly string nameIndex = "Name_index";
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public GameRepository(IMapper mapper,
            IMongoDBCollectionHelper<Game> gamesCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _gamesCollectionHelper = gamesCollectionHelper;
            _gamesCollection = _gamesCollectionHelper.CreateCollection(_databaseSettings);

            //_gamesCollectionHelper.CreateIndexAscending(u => u.Name, nameIndex);

            _mapper = mapper;
        }
        public async Task AddReviewAsync(ObjectId id, ReviewDto reviewDto)
        {
            var filter = Builders<Game>.Filter.Eq(x => x.Id, id);
            var update = Builders<Game>.Update.Push(x => x.ReviewsIds, reviewDto.ReviewId);

            await _gamesCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, ReviewDto reviewDto)
        {
            var filter = Builders<Game>.Filter.Eq(x => x.Id, id);
            var update = Builders<Game>.Update.Pull(x => x.ReviewsIds, reviewDto.ReviewId);

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

        public async Task<IEnumerable<GameCard>> GetGamesAsync(GameParams gameParams)
        {
            var filterByName = Builders<Game>.Filter.Empty;

            if (!(string.IsNullOrEmpty(gameParams.SearchedGame) || string.IsNullOrWhiteSpace(gameParams.SearchedGame)))
            {
                filterByName = Builders<Game>.Filter.Regex(x => x.Name, new BsonRegularExpression(gameParams.SearchedGame, "i"));
            }

            var query = await _gamesCollection.Find(filterByName).ToListAsync();

            var queryList = new List<GameCard>();

            foreach (var document in query)
            {
                queryList.Add(_mapper.Map<GameCard>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = gameParams.OrderBy switch
            {
                "name" => mappedQuery.OrderBy(u => u.Name).OrderByDescending(u => u.Released),
                "rating" => mappedQuery.OrderByDescending(u => u.Rating),
                _ => mappedQuery.OrderByDescending(u => u.Year)

            };

            return mappedQuery;
        }
    }
}
