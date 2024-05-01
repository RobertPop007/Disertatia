using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows.TvShowIds
{
    public class Root
    {
        [JsonProperty("results")]
        public List<Result> Results;
    }
}
