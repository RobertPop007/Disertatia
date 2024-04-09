using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface ITvShowsRepository
    {
        Task<IEnumerable<TvShowCard>> GetTvShowsAsync(TvShowParams userParams);
        Task<TvShow> GetTvShowByIdAsync(ObjectId id);
        Task<TvShow> GetTvShowByFullTitleAsync(string title);
        Task<IEnumerable<TvShow>> GetUserTvShows(Guid userId);
        Task<bool> IsTvShowAlreadyAdded(Guid userId, ObjectId tvShowId);
        Task DeleteShowForUser(Guid userId, ObjectId tvShowId);
        Task AddTvShowToUser(Guid userId, ObjectId tvShowId);
    }
}
