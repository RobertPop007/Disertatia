using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class Videos
    {
        [JsonProperty("results")]
        public List<Result> Results;
    }
}
