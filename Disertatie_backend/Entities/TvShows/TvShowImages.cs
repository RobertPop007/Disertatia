using Disertatie_backend.Entities.Movies;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowImages
    {
        [JsonProperty("backdrops")]
        public List<TvShowBackdrop> Backdrops;

        [JsonProperty("logos")]
        public List<TvShowLogo> Logos;

        [JsonProperty("posters")]
        public List<TvShowPoster> Posters;
    }
}
