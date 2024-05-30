using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IAnimeRepository
    {
        Task<PagedList<AnimeCard>> GetAnimesAsync(AnimeParams userParams);
        Task<Datum> GetAnimeByIdAsync(ObjectId id);
        Task<Datum> GetAnimeByFullTitleAsync(string title);
        Task AddReviewAsync(ObjectId id, Review reviewDto);
        Task DeleteReviewAsync(ObjectId id, Guid reviewId);
    }
}
