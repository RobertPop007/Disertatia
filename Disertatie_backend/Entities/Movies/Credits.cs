using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies
{
    public class Credits
    {
        [JsonProperty("cast")]
        public List<Cast> Cast { get; set; }

        [JsonProperty("crew")]
        public List<Crew> Crew { get; set; }
    }
}
