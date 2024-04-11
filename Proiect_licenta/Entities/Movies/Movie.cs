using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Movies
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
#nullable enable
        [JsonProperty("Id")]
        public string? MovieId { get; set; }
        public string? Title { get; set; }
        public string? OriginalTitle { get; set; }
        public string? FullTitle { get; set; }
        public string? Type { get; set; }
        public string? Year { get; set; }
        public string? Image { get; set; }
        public string? ReleaseDate { get; set; }
        public string? RuntimeMins { get; set; }
        public string? RuntimeStr { get; set; }
        public string? Plot { get; set; }
        public string? PlotLocal { get; set; }
        public bool? PlotLocalIsRtl { get; set; }
        public string? Awards { get; set; }
        public string? Directors { get; set; }
        public List<DirectorList>? DirectorList { get; set; }
        public string? Writers { get; set; }
        public List<WriterList>? WriterList { get; set; }
        public string? Stars { get; set; }
        public List<StarList>? StarList { get; set; }
        public List<ActorList>? ActorList { get; set; }
        public string? Genres { get; set; }
        public List<GenreList>? GenreList { get; set; }
        public string? Companies { get; set; }
        public List<CompanyList>? CompanyList { get; set; }
        public string? Countries { get; set; }
        public List<CountryList>? CountryList { get; set; }
        public string? Languages { get; set; }
        public List<LanguageList>? LanguageList { get; set; }
        public string? ContentRating { get; set; }
        public string? ImDbRating { get; set; }
        public string? ImDbRatingVotes { get; set; }
        public string? MetacriticRating { get; set; }

        public Ratings? Ratings { get; set; }
        public Wikipedia? Wikipedia { get; set; }
        public MoviesImages? Images { get; set; }
        public MoviesTrailer? Trailer { get; set; }
        public BoxOffice? BoxOffice { get; set; }
        public string? Tagline { get; set; }
        public string? Keywords { get; set; }
        public List<Similar>? Similars { get; set; }
        public IList<Review>? Reviews { get; set; }
    }
}
