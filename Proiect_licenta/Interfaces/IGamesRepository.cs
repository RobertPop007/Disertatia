using Disertatie_backend.DTO.Game;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IGamesRepository
    {
        Task<IEnumerable<GameCard>> GetGamesAsync(GameParams userParams);
        Task<Game> GetGameByIdAsync(ObjectId id);
        Task<Game> GetGameByNameAsync(string title);
        Task<IEnumerable<Game>> GetUserGames(Guid userId);
        Task<bool> IsGameAlreadyAdded(Guid userId, ObjectId gameId);
        Task AddGameToUser(Guid userId, ObjectId gameId);
        Task DeleteGameForUser(Guid userId, ObjectId gameId);
    }
}
