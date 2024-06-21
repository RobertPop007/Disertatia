using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies
{
    public class MovieImages
    {
        public List<Backdrop> Backdrops { get; set; }

        public List<Logo> Logos { get; set; }
        public List<Poster> Posters { get; set; }
    }
}
