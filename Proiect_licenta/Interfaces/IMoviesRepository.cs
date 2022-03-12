using Proiect_licenta.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<MovieItem>> GetMoviesAsync();
    }
}
