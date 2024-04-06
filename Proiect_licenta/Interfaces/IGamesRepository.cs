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
        Task<Game> GetGameByIdAsync(int id);
        Task<Game> GetGameByFullTitleAsync(string title);
        Task<List<Game>> GetUserGames(ObjectId userId);
        bool IsGameAlreadyAdded(ObjectId userId, int gameId);
        void DeleteGameForUser(ObjectId userId, int gameId);
        Task<bool> SaveAllAsync();
    }
}
