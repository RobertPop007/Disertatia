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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.DatabaseContext
{
    public class GameRepository : IGamesRepository
    {
        private readonly DataContext _context;
        private readonly IMongoCollection<Game> _gamesCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<Game> _gamesCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string nameIndex = "Name_index";

        public GameRepository(DataContext context, IMongoDBCollectionHelper<Game> gamesCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _gamesCollectionHelper = gamesCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _gamesCollection = _gamesCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _gamesCollectionHelper.CreateIndexAscending(u => u.Name, nameIndex);
        }

        public async Task DeleteGameForUser(ObjectId userId, ObjectId gameId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserGame, gameId);
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddGameToUser(ObjectId userId, ObjectId gameId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserGame, gameId);
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

        //aici umblam cand vedem si partea de frontend, să stim ca intoarcem ce trebuie
        public async Task<List<GameCard>> GetGamesAsync(GameParams gameParams)
        {
            var query = _context.Games
                .Select(game => new GameCard
                {
                    Name = game.Name,
                    Released = game.Released,
                    Id = game.Game_Id,
                    Rating = game.Rating,
                    Background_image = game.Background_image,
                    Year = game.Released.Substring(0, 4)
                }).AsQueryable();

            if (!string.IsNullOrWhiteSpace(gameParams.SearchedGame))
                query = query.Where(u => u.Name.Contains(gameParams.SearchedGame));

            query = gameParams.OrderBy switch
            {
                "name" => query.OrderBy(u => u.Name).OrderBy(u => u.Released),
                "rating" => query.OrderByDescending(u => u.Rating),
                _ => query.OrderByDescending(u => u.Released)

            };

            return await query.ToListAsync();
        }

        public async Task<List<Game>> GetUserGames(ObjectId userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfGamesForUser = new List<Game>();

            foreach (var gameId in user.AppUserGame)
            {
                var game = await GetGameByIdAsync(gameId);

                if (game != null) listOfGamesForUser.Add(game);
            }

            return listOfGamesForUser;
        }

        public async Task<bool> IsGameAlreadyAdded(ObjectId userId, ObjectId gameId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isGameAlreadyAdded = user.AppUserGame.Contains(gameId);
            if (isGameAlreadyAdded == true) return true;
            return false;
        }
    }
}
