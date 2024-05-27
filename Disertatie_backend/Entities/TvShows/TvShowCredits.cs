using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowCredits
    {
        public List<TvShowCast> Cast { get; set; }

        public List<TvShowCrew> Crew { get; set; }
    }
}
