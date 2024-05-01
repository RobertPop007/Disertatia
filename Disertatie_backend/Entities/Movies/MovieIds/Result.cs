using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Movies.MovieIds
{
    public class Result
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
