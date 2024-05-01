using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class Crew
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

        [JsonProperty("credit_id")]
        public string CreditId;

        [JsonProperty("department")]
        public string Department;

        [JsonProperty("job")]
        public string Job;
    }
}
