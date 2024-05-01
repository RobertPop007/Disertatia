using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies
{
    public class MovieImages
    {
        [JsonProperty("backdrops")]
        public List<Backdrop> Backdrops { get; set; }

        [JsonProperty("logos")]
        public List<Logo> Logos { get; set; }

        [JsonProperty("posters")]
        public List<Poster> Posters { get; set; }
    }
}
