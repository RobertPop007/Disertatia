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
        [JsonProperty("id")]
        public ObjectId Id { get; set; }
#nullable enable
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public List<TvShowCreatedBy>? CreatedBy { get; set; }
        public List<int?>? EpisodeRunTime { get; set; }
        public string? FirstAirDate { get; set; }
        public List<TvShowGenre>? Genres { get; set; }
        public string? Homepage { get; set; }

        //[JsonProperty("id")]
        public int? TvShowId { get; set; }
        public bool? InProduction { get; set; }
        public List<string>? Languages { get; set; }
        public string? LastAirDate { get; set; }
        public TvShowLastEpisodeToAir? LastEpisodeToAir { get; set; }
        public string? Name { get; set; }
        public List<TvShowNetwork>? Networks { get; set; }
        public int? NumberOfEpisodes { get; set; }
        public int? NumberOfSeasons { get; set; }
        public List<string>? OriginCountry { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalName { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public List<TvShowProductionCompany>? ProductionCompanies { get; set; }
        public List<TvShowProductionCountry>? ProductionCountries { get; set; }
        public List<TvShowSeason>? Seasons { get; set; }
        public List<TvShowSpokenLanguage>? SpokenLanguages { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Type { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public TvShowVideos? Videos { get; set; }
        public TvShowSimilar? Similar { get; set; }
        public TvShowImages? Images { get; set; }
        public TvShowCredits? Credits { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
