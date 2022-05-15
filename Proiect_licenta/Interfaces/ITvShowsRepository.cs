using Proiect_licenta.DTO.TvShows;
using Proiect_licenta.Entities.TvShows;
using Proiect_licenta.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
{
    public interface ITvShowsRepository
    {
        Task<List<TvShowCard>> GetTvShowsAsync(TvShowParams userParams);
        Task<TvShow> GetTvShowByIdAsync(string id);
        Task<TvShow> GetTvShowByFullTitleAsync(string title);
        Task<List<TvShow>> GetUserTvShows(int userId);
        bool IsTvShowAlreadyAdded(int userId, string tvShowId);
        void DeleteShowForUser(int userId, string tvShowId);
        Task<bool> SaveAllAsync();
    }
}
