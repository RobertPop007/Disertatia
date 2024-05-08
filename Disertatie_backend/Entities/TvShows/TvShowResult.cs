using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowResult
    {
        [JsonProperty("iso_639_1")]
        public string Iso6391;

        [JsonProperty("iso_3166_1")]
        public string Iso31661;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("key")]
        public string Key;

        [JsonProperty("site")]
        public string Site;

        [JsonProperty("size")]
        public int? Size;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("official")]
        public bool? Official;

        [JsonProperty("published_at")]
        public DateTime? PublishedAt;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("adult")]
        public bool? Adult;

        [JsonProperty("backdrop_path")]
        public string BackdropPath;

        [JsonProperty("genre_ids")]
        public List<int?> GenreIds;

        [JsonProperty("origin_country")]
        public List<string> OriginCountry;

        [JsonProperty("original_language")]
        public string OriginalLanguage;

        [JsonProperty("original_name")]
        public string OriginalName;

        [JsonProperty("overview")]
        public string Overview;

        [JsonProperty("popularity")]
        public double? Popularity;

        [JsonProperty("poster_path")]
        public string PosterPath;

        [JsonProperty("first_air_date")]
        public string FirstAirDate;

        [JsonProperty("vote_average")]
        public double? VoteAverage;

        [JsonProperty("vote_count")]
        public int? VoteCount;
    }
}
