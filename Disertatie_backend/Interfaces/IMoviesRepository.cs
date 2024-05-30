using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IMoviesRepository
    {
        Task<PagedList<MovieCard>> GetMoviesAsync(MovieParams userParams);
        Task<Movie> GetMovieByIdAsync(ObjectId id);
        Task<Movie> GetMovieByTitleAsync(string name);
        Task AddReviewAsync(ObjectId id, Review review);
        Task DeleteReviewAsync(ObjectId id, Guid reviewId);
    }
}
