using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<AnimeCard>> GetAnimesAsync(AnimeParams userParams);
        Task<Datum> GetAnimeByIdAsync(ObjectId id);
        Task<Datum> GetAnimeByFullTitleAsync(string title);
        Task<IEnumerable<Datum>> GetUserAnimes(Guid userId);
        Task<bool> IsAnimeAlreadyAdded(Guid userId, ObjectId animeId);
        Task AddAnimeToUser(Guid userId, ObjectId animeId);
        Task DeleteAnimeForUser(Guid userId, ObjectId animeId);
    }
}
