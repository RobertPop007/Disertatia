using Proiect_licenta.DTO.Manga;
using Proiect_licenta.Entities.Manga;
using Proiect_licenta.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
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
