using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows.TvShowIds
{
    public class TvShowRoot
    {
        [JsonProperty("results")]
        public List<TvShowsResult> Results;
    }
}
