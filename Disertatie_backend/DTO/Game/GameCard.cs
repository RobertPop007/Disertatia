using MongoDB.Bson;

namespace Disertatie_backend.DTO.Game
{
    public class GameCard
    {
#nullable enable
        public string? Name { get; set; }
        public string? Released { get; set; }
        public ObjectId Id { get; set; }
        public double? Rating { get; set; }
        public string? Background_image { get; set; }
        public string? Year { get; set; }
    }
}
