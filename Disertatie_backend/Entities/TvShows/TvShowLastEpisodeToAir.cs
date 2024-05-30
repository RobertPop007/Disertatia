namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowLastEpisodeToAir
    {
        public int? Id { get; set; }

        public string Overview { get; set; }

        public string Name { get; set; }

        public double? VoteAverage { get; set; }

        public int? VoteCount { get; set; }

        public string AirDate { get; set; }

        public int? EpisodeNumber { get; set; }

        public string EpisodeType { get; set; }

        public string ProductionCode { get; set; }

        public int? Runtime { get; set; }

        public int? SeasonNumber { get; set; }

        public int? ShowId { get; set; }

        public string StillPath { get; set; }
    }
}
