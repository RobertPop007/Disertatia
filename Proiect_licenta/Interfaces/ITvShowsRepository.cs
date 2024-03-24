using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
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
