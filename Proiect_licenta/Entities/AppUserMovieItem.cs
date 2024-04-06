using Disertatie_backend.Entities.Movies;
using MongoDB.Bson;

namespace Disertatie_backend.Entities
{
    public class AppUserMovieItem
    {
        public ObjectId AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string MovieId { get; set; }
        public Movie MovieItem { get; set; }
    }
}
