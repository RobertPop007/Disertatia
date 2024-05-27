using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowSeason
    {
        public string AirDate { get; set; }

        public int? EpisodeCount { get; set; }

        public int? Id { get; set; }

        public string Name { get; set; }

        public string Overview { get; set; }

        public string PosterPath { get; set; }

        public int? SeasonNumber { get; set; }

        public double? VoteAverage { get; set; }
    }
}
