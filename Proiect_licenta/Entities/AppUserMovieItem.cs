using Proiect_licenta.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.Entities;

public class AppUserMovieItem
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public string MovieId { get; set; }
    public Movie MovieItem { get; set; }
}
