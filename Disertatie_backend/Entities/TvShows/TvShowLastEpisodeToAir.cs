using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowLastEpisodeToAir
    {
        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("overview")]
        public string Overview;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("vote_average")]
        public double? VoteAverage;

        [JsonProperty("vote_count")]
        public int? VoteCount;

        [JsonProperty("air_date")]
        public string AirDate;

        [JsonProperty("episode_number")]
        public int? EpisodeNumber;

        [JsonProperty("episode_type")]
        public string EpisodeType;

        [JsonProperty("production_code")]
        public string ProductionCode;

        [JsonProperty("runtime")]
        public int? Runtime;

        [JsonProperty("season_number")]
        public int? SeasonNumber;

        [JsonProperty("show_id")]
        public int? ShowId;

        [JsonProperty("still_path")]
        public string StillPath;
    }
}
