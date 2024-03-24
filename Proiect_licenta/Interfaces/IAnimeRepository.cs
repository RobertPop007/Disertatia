using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
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
