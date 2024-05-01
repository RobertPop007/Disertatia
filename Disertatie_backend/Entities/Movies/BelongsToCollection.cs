using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Movies
{
    public class BelongsToCollection
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("poster_path")]
        public object PosterPath { get; set; }

        [JsonProperty("backdrop_path")]
        public object BackdropPath { get; set; }
    }
}
