using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowProductionCountry
    {
        [JsonProperty("iso_3166_1")]
        public string Iso31661;

        [JsonProperty("name")]
        public string Name;
    }
}
