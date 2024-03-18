using Proiect_licenta.Entities.Movies;

namespace Proiect_licenta.Entities;

public class AppUserMovieItem
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public string MovieId { get; set; }
    public Movie MovieItem { get; set; }
}
