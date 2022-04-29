using Proiect_licenta.DTO.Movies;
using Proiect_licenta.Entities;
using Proiect_licenta.Entities.Movies;
using Proiect_licenta.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetMoviesAsync(MovieParams userParams);
        Task<Movie> GetMovieByIdAsync(string id);
        Task<Movie> GetMovieByFullTitleAsync(string fullTitle);
        Task<List<Movie>> GetUserMovies(int userId);
        bool IsMovieAlreadyAdded(int userId, string movieId);
        void DeleteMovieForUser(int userId, string movieId);
        Task<bool> SaveAllAsync();
    }
}
