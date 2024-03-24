using System.Collections.Generic;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowGeneralInfo
    {
        public List<TvShowItem> Items { get; set; }
        public string ErrorMessage { get; set; }
    }
}
