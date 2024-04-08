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
        Task<TvShow> GetTvShowByIdAsync(ObjectId id);
        Task<TvShow> GetTvShowByFullTitleAsync(string title);
        Task<List<TvShow>> GetUserTvShows(ObjectId userId);
        Task<bool> IsTvShowAlreadyAdded(ObjectId userId, ObjectId tvShowId);
        Task DeleteShowForUser(ObjectId userId, ObjectId tvShowId);
        Task AddTvShowToUser(ObjectId userId, ObjectId tvShowId);
    }
}
