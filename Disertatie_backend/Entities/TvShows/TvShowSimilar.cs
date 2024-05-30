using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowSimilar
    {
        public int? Page { get; set; }

        public List<TvShowResult> Results { get; set; }

        public int? TotalPages { get; set; }

        public int? TotalResults { get; set; }
    }
}
