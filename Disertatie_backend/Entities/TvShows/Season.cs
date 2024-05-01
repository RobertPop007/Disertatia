using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class Season
    {
        [JsonProperty("air_date")]
        public string AirDate;

        [JsonProperty("episode_count")]
        public int? EpisodeCount;

        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("overview")]
        public string Overview;

        [JsonProperty("poster_path")]
        public string PosterPath;

        [JsonProperty("season_number")]
        public int? SeasonNumber;

        [JsonProperty("vote_average")]
        public double? VoteAverage;
    }
}
