using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<MovieCard>> GetMoviesAsync(MovieParams userParams);
        Task<Movie> GetMovieByIdAsync(string id);
        Task<Movie> GetMovieByTitleAsync(string title);
        Task<List<Movie>> GetUserMovies(ObjectId userId);
        bool IsMovieAlreadyAdded(ObjectId userId, string movieId);
        void DeleteMovieForUser(ObjectId userId, string movieId);
        Task<bool> SaveAllAsync();
    }
}
