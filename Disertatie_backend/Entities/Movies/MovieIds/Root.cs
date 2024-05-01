using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies.MovieIds
{
    public class Root
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
}
