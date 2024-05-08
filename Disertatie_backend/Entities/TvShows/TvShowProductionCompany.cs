using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowProductionCompany
    {
        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("logo_path")]
        public string LogoPath;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("origin_country")]
        public string OriginCountry;
    }
}
