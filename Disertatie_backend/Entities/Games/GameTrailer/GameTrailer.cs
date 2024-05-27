using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Games.GameTrailer
{
    public class GameTrailer
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
}
