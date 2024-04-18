using MongoDB.Bson;

namespace Disertatie_backend.DTO.Movies
{
    public class MovieCard
    {
        public string FullTitle { get; set; }
        public string Title { get; set; }
        public ObjectId Id { get; set; }
        public string ImDbRating { get; set; }
        public string Image { get; set; }
        public string Year { get; set; }
    }
}
