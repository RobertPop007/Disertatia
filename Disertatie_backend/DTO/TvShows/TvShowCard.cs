using MongoDB.Bson;

namespace Disertatie_backend.DTO.TvShows
{
    public class TvShowCard
    {
        public string OriginalName { get; set; }
        public string Name { get; set; }
        public ObjectId Id { get; set; }
        public double VoteAverage { get; set; }
        public string PosterPath { get; set; }
        public string FirstAirDate { get; set; }
        public double Popularity { get; set; }
    }
}
