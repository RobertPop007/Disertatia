using Disertatie_backend.DTO.Game;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IGamesRepository
    {
        Task<List<GameCard>> GetGamesAsync(GameParams userParams);
        Task<Game> GetGameByIdAsync(ObjectId id);
        Task<Game> GetGameByNameAsync(string title);
        Task<List<Game>> GetUserGames(ObjectId userId);
        Task<bool> IsGameAlreadyAdded(ObjectId userId, ObjectId gameId);
        Task AddGameToUser(ObjectId userId, ObjectId gameId);
        Task DeleteGameForUser(ObjectId userId, ObjectId gameId);
    }
}
