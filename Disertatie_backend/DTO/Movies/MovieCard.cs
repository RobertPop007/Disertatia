using MongoDB.Bson;

namespace Disertatie_backend.DTO.Movies
{
    public class MovieCard
    {
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public ObjectId Id { get; set; }
        public double VoteAverage { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
    }
}
