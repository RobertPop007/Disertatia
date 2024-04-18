using Disertatie_backend.DTO;
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
        Task AddReviewAsync(ObjectId id, ReviewDto reviewDto);
        Task DeleteReviewAsync(ObjectId id, ReviewDto reviewDto);
    }
}
