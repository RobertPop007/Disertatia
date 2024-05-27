using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Disertatie_backend.Entities.Movies
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public ObjectId Id { get; set; }
#nullable enable

        public string? BackdropPath { get; set; }
        public BelongsToCollection? BelongsToCollection { get; set; }
        public int? Budget { get; set; }
        public List<MovieGenre>? Genres { get; set; }
        public string? Homepage { get; set; }

        //[JsonProperty("id")]
        public int? MovieId { get; set; }
        public string? ImdbId { get; set; }
        public List<string>? OriginCountry { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public List<ProductionCompany>? ProductionCompanies { get; set; }
        public List<ProductionCountry>? ProductionCountries { get; set; }
        public string? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public int? Runtime { get; set; }
        public List<SpokenLanguage>? SpokenLanguages { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public Videos? Videos { get; set; }
        public Similar? Similar { get; set; }
        public MovieImages? Images { get; set; }
        public Credits? Credits { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
