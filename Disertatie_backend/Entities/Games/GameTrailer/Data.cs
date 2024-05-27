using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Games.GameTrailer
{
    public class Data
    {
        [JsonProperty("max")]
        public string Max { get; set; }
    }
}