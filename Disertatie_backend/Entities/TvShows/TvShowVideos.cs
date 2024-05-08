using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowVideos
    {
        [JsonProperty("results")]
        public List<TvShowResult> Results;
    }
}
