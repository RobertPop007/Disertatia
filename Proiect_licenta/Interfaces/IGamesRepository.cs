using Disertatie_backend.DTO.Game;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IGamesRepository
    {
        Task<List<GameCard>> GetGamesAsync(GameParams userParams);
        Task<Game> GetGameByIdAsync(int id);
        Task<Game> GetGameByFullTitleAsync(string title);
        Task<List<Game>> GetUserGames(int userId);
        bool IsGameAlreadyAdded(int userId, int gameId);
        void DeleteGameForUser(int userId, int gameId);
        Task<bool> SaveAllAsync();
    }
}
