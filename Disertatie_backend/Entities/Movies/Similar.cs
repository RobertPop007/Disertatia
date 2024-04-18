using MongoDB.Bson;

namespace Disertatie_backend.Entities.Movies
{
    public class Similar
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Image { get; set; }
        public string ImDbRating { get; set; }
    }
}
