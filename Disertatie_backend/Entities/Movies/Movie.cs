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

        [JsonProperty("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonProperty("belongs_to_collection")]
        public BelongsToCollection? BelongsToCollection { get; set; }

        [JsonProperty("budget")]
        public int? Budget { get; set; }

        [JsonProperty("genres")]
        public List<MovieGenre>? Genres { get; set; }

        [JsonProperty("homepage")]
        public string? Homepage { get; set; }

        //[JsonProperty("id")]
        public int? MovieId { get; set; }

        [JsonProperty("imdb_id")]
        public string? ImdbId { get; set; }

        [JsonProperty("origin_country")]
        public List<string>? OriginCountry { get; set; }

        [JsonProperty("original_language")]
        public string? OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string? OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("production_companies")]
        public List<ProductionCompany>? ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public List<ProductionCountry>? ProductionCountries { get; set; }

        [JsonProperty("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonProperty("revenue")]
        public long? Revenue { get; set; }

        [JsonProperty("runtime")]
        public int? Runtime { get; set; }

        [JsonProperty("spoken_languages")]
        public List<SpokenLanguage>? SpokenLanguages { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("tagline")]
        public string? Tagline { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }

        [JsonProperty("videos")]
        public Videos? Videos { get; set; }

        [JsonProperty("similar")]
        public Similar? Similar { get; set; }

        [JsonProperty("images")]
        public MovieImages? Images { get; set; }
        [JsonProperty("credits")]
        public Credits? Credits { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
