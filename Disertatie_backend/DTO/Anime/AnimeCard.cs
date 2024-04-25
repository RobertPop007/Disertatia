using Disertatie_backend.Entities.Anime;
using MongoDB.Bson;

namespace Disertatie_backend.DTO.Anime
{
    public class AnimeCard
    {
        public string Title { get; set; }
        public string Popularity { get; set; }
        public ObjectId Id { get; set; }
        public double? Score { get; set; }
        public string Image { get; set; }
        public string Year { get; set; }
    }
}
