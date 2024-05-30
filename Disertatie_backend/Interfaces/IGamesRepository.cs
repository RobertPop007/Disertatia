using Disertatie_backend.DTO.Game;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IGamesRepository
    {
        Task<PagedList<GameCard>> GetGamesAsync(GameParams userParams);
        Task<Game> GetGameByIdAsync(ObjectId id);
        Task<Game> GetGameByNameAsync(string title);
        Task AddReviewAsync(ObjectId id, Review review);
        Task DeleteReviewAsync(ObjectId id, Guid reviewId);
    }
}
