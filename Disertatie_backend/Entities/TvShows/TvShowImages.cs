using Disertatie_backend.Entities.Movies;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowImages
    {
        public List<TvShowBackdrop> Backdrops { get; set; }

        public List<TvShowLogo> Logos { get; set; }

        public List<TvShowPoster> Posters { get; set; }
    }
}
