using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class Images
    {
        [JsonProperty("backdrops")]
        public List<Backdrop> Backdrops;

        [JsonProperty("logos")]
        public List<Logo> Logos;

        [JsonProperty("posters")]
        public List<Poster> Posters;
    }
}
