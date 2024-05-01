using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class Genre
    {
        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("name")]
        public string Name;
    }
}
