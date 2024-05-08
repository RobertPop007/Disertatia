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
        public ObjectId TvShowId { get; set; }
#nullable enable
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonProperty("created_by")]
        public List<TvShowCreatedBy>? CreatedBy { get; set; }

        [JsonProperty("episode_run_time")]
        public List<int?>? EpisodeRunTime { get; set; }

        [JsonProperty("first_air_date")]
        public string? FirstAirDate { get; set; }

        [JsonProperty("genres")]
        public List<TvShowGenre>? Genres { get; set; }

        [JsonProperty("homepage")]
        public string? Homepage { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("in_production")]
        public bool? InProduction { get; set; }

        [JsonProperty("languages")]
        public List<string>? Languages { get; set; }

        [JsonProperty("last_air_date")]
        public string? LastAirDate { get; set; }

        [JsonProperty("last_episode_to_air")]
        public TvShowLastEpisodeToAir? LastEpisodeToAir { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("networks")]
        public List<TvShowNetwork>? Networks { get; set; }

        [JsonProperty("number_of_episodes")]
        public int? NumberOfEpisodes { get; set; }

        [JsonProperty("number_of_seasons")]
        public int? NumberOfSeasons { get; set; }

        [JsonProperty("origin_country")]
        public List<string>? OriginCountry { get; set; }

        [JsonProperty("original_language")]
        public string? OriginalLanguage { get; set; }

        [JsonProperty("original_name")]
        public string? OriginalName { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("production_companies")]
        public List<TvShowProductionCompany>? ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public List<TvShowProductionCountry>? ProductionCountries { get; set; }

        [JsonProperty("seasons")]
        public List<TvShowSeason>? Seasons { get; set; }

        [JsonProperty("spoken_languages")]
        public List<TvShowSpokenLanguage>? SpokenLanguages { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("tagline")]
        public string? Tagline { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }

        [JsonProperty("videos")]
        public TvShowVideos? Videos { get; set; }

        [JsonProperty("similar")]
        public TvShowSimilar? Similar { get; set; }

        [JsonProperty("images")]
        public TvShowImages? Images { get; set; }

        [JsonProperty("credits")]
        public TvShowCredits? Credits { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
