using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.Entities.Movies;

public class MovieGeneralInfo
{
    public List<MovieItem> Items { get; set; }
    public string ErrorMessage { get; set; }
}
