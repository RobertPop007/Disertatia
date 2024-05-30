using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Books
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public int? BookID { get; set; }

        public string Title { get; set; }

        public string Authors { get; set; }

        public double? AverageRating { get; set; }

        public string Isbn { get; set; }

        public long? Isbn13 { get; set; }

        public string LanguageCode { get; set; }

        public int? NumPages { get; set; }

        public int? RatingsCount { get; set; }

        public int? TextReviewsCount { get; set; }

        public string PublicationDate { get; set; }

        public string Publisher { get; set; }
        public string CoverUrl { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
