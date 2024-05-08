using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowSpokenLanguage
    {
        [JsonProperty("english_name")]
        public string EnglishName;

        [JsonProperty("iso_639_1")]
        public string Iso6391;

        [JsonProperty("name")]
        public string Name;
    }
}
