using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class Cast
    {
        [JsonProperty("adult")]
        public bool? Adult;

        [JsonProperty("gender")]
        public int? Gender;

        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("known_for_department")]
        public string KnownForDepartment;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("original_name")]
        public string OriginalName;

        [JsonProperty("popularity")]
        public double? Popularity;

        [JsonProperty("profile_path")]
        public string ProfilePath;

        [JsonProperty("character")]
        public string Character;

        [JsonProperty("credit_id")]
        public string CreditId;

        [JsonProperty("order")]
        public int? Order;

    }
}
