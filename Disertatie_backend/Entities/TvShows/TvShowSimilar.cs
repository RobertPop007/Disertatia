using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowSimilar
    {
        [JsonProperty("page")]
        public int? Page;

        [JsonProperty("results")]
        public List<TvShowResult> Results;

        [JsonProperty("total_pages")]
        public int? TotalPages;

        [JsonProperty("total_results")]
        public int? TotalResults;
    }
}
