using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvSeriesInfo
    {
#nullable enable
        public string? YearEnd { get; set; }
        public string? Creators { get; set; }
        public List<TvShowCreatorList>? CreatorList { get; set; }
        public string[]? Seasons { get; set; }
    }
}
