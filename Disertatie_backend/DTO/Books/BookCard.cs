using MongoDB.Bson;

namespace Disertatie_backend.DTO.Books
{
    public class BookCard
    {
        public string Title { get; set; }
        public ObjectId Id { get; set; }
        public string Authors { get; set; }
        public double? AverageRating { get; set; }
        public int? RatingsCount { get; set; }
        public int? TextReviewsCount { get; set; }
        public string PublicationDate { get; set; }
        public string Publisher { get; set; }
        public string CoverUrl { get; set; }
    }
}
