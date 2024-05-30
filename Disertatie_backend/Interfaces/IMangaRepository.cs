using Disertatie_backend.DTO.Manga;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IMangaRepository
    {
        Task<PagedList<MangaCard>> GetMangasAsync(MangaParams userParams);
        Task<DatumManga> GetMangaByIdAsync(ObjectId id);
        Task<DatumManga> GetMangaByFullTitleAsync(string title);
        Task AddReviewAsync(ObjectId id, Review review);
        Task DeleteReviewAsync(ObjectId id, Guid reviewId);
    }
}
