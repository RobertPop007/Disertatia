using Disertatie_backend.DTO.Manga;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IMangaRepository
    {
        Task<List<MangaCard>> GetMangasAsync(MangaParams userParams);
        Task<DatumManga> GetMangaByIdAsync(ObjectId id);
        Task<DatumManga> GetMangaByFullTitleAsync(string title);
        Task<List<DatumManga>> GetUserMangas(ObjectId userId);
        Task<bool> IsMangaAlreadyAdded(ObjectId userId, ObjectId mangaId);
        Task DeleteMangaForUser(ObjectId userId, ObjectId mangaId);
        Task AddMangaToUser(ObjectId userId, ObjectId mangaId);
    }
}
