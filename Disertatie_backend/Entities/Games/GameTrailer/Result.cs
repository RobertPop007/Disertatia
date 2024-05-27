using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Games.GameTrailer
{
    public class Result
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
