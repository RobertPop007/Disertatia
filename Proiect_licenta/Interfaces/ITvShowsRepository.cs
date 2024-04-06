using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface ITvShowsRepository
    {
        Task<List<TvShowCard>> GetTvShowsAsync(TvShowParams userParams);
        Task<TvShow> GetTvShowByIdAsync(string id);
        Task<TvShow> GetTvShowByFullTitleAsync(string title);
        Task<List<TvShow>> GetUserTvShows(ObjectId userId);
        bool IsTvShowAlreadyAdded(ObjectId userId, string tvShowId);
        void DeleteShowForUser(ObjectId userId, string tvShowId);
        Task<bool> SaveAllAsync();
    }
}
