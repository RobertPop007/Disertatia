using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<MovieCard>> GetMoviesAsync(MovieParams userParams);
        Task<Movie> GetMovieByIdAsync(ObjectId id);
        Task<Movie> GetMovieByTitleAsync(string title);
    }
}
