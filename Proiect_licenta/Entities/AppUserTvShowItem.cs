using Proiect_licenta.Entities.TvShows;

namespace Proiect_licenta.Entities;

public class AppUserTvShowItem
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public string TvShowId { get; set; }
    public TvShow TvShowItem { get; set; }
}
