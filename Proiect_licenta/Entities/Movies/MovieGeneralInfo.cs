using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies
{
    public class MovieGeneralInfo
    {
        public List<MovieItem> Items { get; set; }
        public string ErrorMessage { get; set; }
    }
}
