using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Books
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [JsonProperty("bookID", NullValueHandling = NullValueHandling.Ignore)]
        public int? BookID { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("authors", NullValueHandling = NullValueHandling.Ignore)]
        public string Authors { get; set; }

        [JsonProperty("average_rating", NullValueHandling = NullValueHandling.Ignore)]
        public double? AverageRating { get; set; }

        [JsonProperty("isbn", NullValueHandling = NullValueHandling.Ignore)]
        public string Isbn { get; set; }

        [JsonProperty("isbn13", NullValueHandling = NullValueHandling.Ignore)]
        public long? Isbn13 { get; set; }

        [JsonProperty("language_code", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; set; }

        [JsonProperty("num_pages", NullValueHandling = NullValueHandling.Ignore)]
        public int? NumPages { get; set; }

        [JsonProperty("ratings_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? RatingsCount { get; set; }

        [JsonProperty("text_reviews_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? TextReviewsCount { get; set; }

        [JsonProperty("publication_date", NullValueHandling = NullValueHandling.Ignore)]
        public string PublicationDate { get; set; }

        [JsonProperty("publisher", NullValueHandling = NullValueHandling.Ignore)]
        public string Publisher { get; set; }

        public string CoverUrl { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
