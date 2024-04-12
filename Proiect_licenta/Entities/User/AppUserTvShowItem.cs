using Disertatie_backend.Entities.TvShows;
using MongoDB.Bson;

namespace Disertatie_backend.Entities.User
{
    public class AppUserTvShowItem
    {
        public ObjectId AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string TvShowId { get; set; }
        public TvShow TvShowItem { get; set; }
    }
}
