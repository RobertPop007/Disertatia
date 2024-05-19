using MongoDB.Bson;

namespace Disertatie_backend.DTO.TvShows
{
    public class TvShowCard
    {
        public string FullTitle { get; set; }
        public string Title { get; set; }
        public ObjectId TvShowId { get; set; }
        public string ImDbRating { get; set; }
        public string Image { get; set; }
        public string Year { get; set; }
    }
}
