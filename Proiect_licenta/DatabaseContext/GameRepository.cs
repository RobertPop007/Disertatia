using AutoMapper;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO.Game;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.DatabaseContext
{
    public class GameRepository : IGamesRepository
    {
        private readonly IMongoCollection<Game> _gamesCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<Game> _gamesCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string nameIndex = "Name_index";

        private readonly IMapper _mapper;

        public GameRepository(IMapper mapper, IMongoDBCollectionHelper<Game> gamesCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _gamesCollectionHelper = gamesCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _gamesCollection = _gamesCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _gamesCollectionHelper.CreateIndexAscending(u => u.Name, nameIndex);

            _mapper = mapper;
        }

        public async Task DeleteGameForUser(Guid userId, ObjectId gameId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserGame, gameId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddGameToUser(Guid userId, ObjectId gameId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserGame, gameId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
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
            if (string.IsNullOrEmpty(gameParams.SearchedGame) || string.IsNullOrWhiteSpace(gameParams.SearchedGame)) return null;

            var filterByTitle = Builders<Game>.Filter.Where(x => x.Name.Contains(gameParams.SearchedGame)) |
                Builders<Game>.Filter.Where(x => x.Name_original.Contains(gameParams.SearchedGame)) |
                Builders<Game>.Filter.Where(x => x.Reddit_name.Contains(gameParams.SearchedGame));

            var query = await _gamesCollection.Find(filterByTitle).ToListAsync();

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

        public async Task<IEnumerable<Game>> GetUserGames(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfGamesForUser = new List<Game>();

            foreach (var gameId in user.AppUserGame)
            {
                var game = await GetGameByIdAsync(new ObjectId(gameId));

                if (game != null) listOfGamesForUser.Add(game);
            }

            return listOfGamesForUser;
        }

        public async Task<bool> IsGameAlreadyAdded(Guid userId, ObjectId gameId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isGameAlreadyAdded = user.AppUserGame.Contains(gameId.ToString());
            if (isGameAlreadyAdded == true) return true;
            return false;
        }
    }
}
