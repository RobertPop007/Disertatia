using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Movies
{
    public class MovieGenre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
