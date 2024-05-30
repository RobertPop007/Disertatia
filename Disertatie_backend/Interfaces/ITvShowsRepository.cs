using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface ITvShowsRepository
    {
        Task<PagedList<TvShowCard>> GetTvShowsAsync(TvShowParams userParams);
        Task<TvShow> GetTvShowByIdAsync(ObjectId id);
        Task<TvShow> GetTvShowByFullTitleAsync(string title);
        Task AddReviewAsync(ObjectId id, Review review);
        Task DeleteReviewAsync(ObjectId id, Guid reviewId);
    }
}
