using System.Collections.Generic;

namespace Proiect_licenta.Entities.Movies;

public class MovieGeneralInfo
{
    public List<MovieItem> Items { get; set; }
    public string ErrorMessage { get; set; }
}
