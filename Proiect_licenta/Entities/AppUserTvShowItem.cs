using Disertatie_backend.Entities.TvShows;

namespace Disertatie_backend.Entities
{
    public class AppUserTvShowItem
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string TvShowId { get; set; }
        public TvShow TvShowItem { get; set; }
    }
}
