using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class Credits
    {
        [JsonProperty("cast")]
        public List<Cast> Cast;

        [JsonProperty("crew")]
        public List<Crew> Crew;
    }
}
