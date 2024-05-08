using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowLogo
    {
        [JsonProperty("aspect_ratio")]
        public double? AspectRatio;

        [JsonProperty("height")]
        public int? Height;

        [JsonProperty("iso_639_1")]
        public string Iso6391;

        [JsonProperty("file_path")]
        public string FilePath;

        [JsonProperty("vote_average")]
        public double? VoteAverage;

        [JsonProperty("vote_count")]
        public int? VoteCount;

        [JsonProperty("width")]
        public int? Width;
    }
}
