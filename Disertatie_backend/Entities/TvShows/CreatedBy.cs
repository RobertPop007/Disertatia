using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class CreatedBy
    {
        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("credit_id")]
        public string CreditId;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("original_name")]
        public string OriginalName;

        [JsonProperty("gender")]
        public int? Gender;

        [JsonProperty("profile_path")]
        public string ProfilePath;
    }
}
