using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowCredits
    {
        [JsonProperty("cast")]
        public List<TvShowCast> Cast;

        [JsonProperty("crew")]
        public List<TvShowCrew> Crew;
    }
}
