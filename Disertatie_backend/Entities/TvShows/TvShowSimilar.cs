using MongoDB.Bson;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowSimilar
    {
        public ObjectId? Id { get; set; }
        public string TvShow_Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImDbRating { get; set; }
    }
}
