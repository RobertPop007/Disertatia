using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowProductionCompany
    {
        public int? Id { get; set; }

        public string LogoPath { get; set; }

        public string Name { get; set; }

        public string OriginCountry { get; set; }
    }
}
