using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies
{
    public class Videos
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
}
