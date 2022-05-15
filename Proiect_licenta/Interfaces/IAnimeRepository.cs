using Proiect_licenta.DTO.Anime;
using Proiect_licenta.Entities.Anime;
using Proiect_licenta.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
{
    public interface IAnimeRepository
    {
        Task<List<AnimeCard>> GetAnimesAsync(AnimeParams userParams);
        Task<Datum> GetAnimeByIdAsync(int id);
        Task<Datum> GetAnimeByFullTitleAsync(string title);
        Task<List<Datum>> GetUserAnimes(int userId);
        bool IsAnimeAlreadyAdded(int userId, int animeId);
        void DeleteAnimeForUser(int userId, int animeId);
        Task<bool> SaveAllAsync();
    }
}
