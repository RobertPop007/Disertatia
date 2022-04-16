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
        Task<PagedList<MovieItem>> GetMoviesAsync(MovieParams userParams);
        Task<MovieItem> GetMovieByIdAsync(string id);
        Task<MovieItem> GetMovieByFullTitleAsync(string fullTitle);
    }
}
