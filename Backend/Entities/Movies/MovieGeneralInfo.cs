using System.Collections.Generic;

namespace Backend.Entities.Movies;

public class MovieGeneralInfo
{
    public List<MovieItem> Items { get; set; }
    public string ErrorMessage { get; set; }
}
