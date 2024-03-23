using Backend.Entities.TvShows;

namespace Backend.Entities;

public class AppUserTvShowItem
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public string TvShowId { get; set; }
    public TvShow TvShowItem { get; set; }
}
