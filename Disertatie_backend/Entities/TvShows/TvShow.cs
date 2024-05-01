using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShow
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
#nullable enable
        [JsonProperty("adult")]
        public bool? Adult;

        [JsonProperty("backdrop_path")]
        public string? BackdropPath;

        [JsonProperty("created_by")]
        public List<CreatedBy>? CreatedBy;

        [JsonProperty("episode_run_time")]
        public List<int?>? EpisodeRunTime;

        [JsonProperty("first_air_date")]
        public string? FirstAirDate;

        [JsonProperty("genres")]
        public List<Genre>? Genres;

        [JsonProperty("homepage")]
        public string? Homepage;

        [JsonProperty("id")]
        public int? MovieId;

        [JsonProperty("in_production")]
        public bool? InProduction;

        [JsonProperty("languages")]
        public List<string>? Languages;

        [JsonProperty("last_air_date")]
        public string? LastAirDate;

        [JsonProperty("last_episode_to_air")]
        public LastEpisodeToAir? LastEpisodeToAir;

        [JsonProperty("name")]
        public string? Name;

        [JsonProperty("networks")]
        public List<Network>? Networks;

        [JsonProperty("number_of_episodes")]
        public int? NumberOfEpisodes;

        [JsonProperty("number_of_seasons")]
        public int? NumberOfSeasons;

        [JsonProperty("origin_country")]
        public List<string>? OriginCountry;

        [JsonProperty("original_language")]
        public string? OriginalLanguage;

        [JsonProperty("original_name")]
        public string? OriginalName;

        [JsonProperty("overview")]
        public string? Overview;

        [JsonProperty("popularity")]
        public double? Popularity;

        [JsonProperty("poster_path")]
        public string? PosterPath;

        [JsonProperty("production_companies")]
        public List<ProductionCompany>? ProductionCompanies;

        [JsonProperty("production_countries")]
        public List<ProductionCountry>? ProductionCountries;

        [JsonProperty("seasons")]
        public List<Season>? Seasons;

        [JsonProperty("spoken_languages")]
        public List<SpokenLanguage>? SpokenLanguages;

        [JsonProperty("status")]
        public string? Status;

        [JsonProperty("tagline")]
        public string? Tagline;

        [JsonProperty("type")]
        public string? Type;

        [JsonProperty("vote_average")]
        public double? VoteAverage;

        [JsonProperty("vote_count")]
        public int? VoteCount;

        [JsonProperty("videos")]
        public Videos? Videos;

        [JsonProperty("similar")]
        public Similar? Similar;

        [JsonProperty("images")]
        public Images? Images;

        [JsonProperty("credits")]
        public Credits? Credits;
        public ICollection<Guid>? ReviewsIds { get; set; } = new List<Guid>();
    }
}
