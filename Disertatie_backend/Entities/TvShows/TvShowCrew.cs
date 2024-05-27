using Newtonsoft.Json;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowCrew
    {
        public bool? Adult { get; set; }

        public int? Gender { get; set; }

        public int? Id { get; set; }

        public string KnownForDepartment { get; set; }

        public string Name { get; set; }

        public string OriginalName { get; set; }

        public double? Popularity { get; set; }

        public string ProfilePath { get; set; }

        public string CreditId { get; set; }

        public string Department { get; set; }

        public string Job { get; set; }
    }
}
