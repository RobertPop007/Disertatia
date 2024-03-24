using Disertatie_backend.DTO.Manga;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IMangaRepository
    {
        Task<List<MangaCard>> GetMangasAsync(MangaParams userParams);
        Task<DatumManga> GetMangaByIdAsync(int id);
        Task<DatumManga> GetMangaByFullTitleAsync(string title);
        Task<List<DatumManga>> GetUserMangas(int userId);
        bool IsMangaAlreadyAdded(int userId, int mangaId);
        void DeleteMangaForUser(int userId, int mangaId);
        Task<bool> SaveAllAsync();
    }
}
