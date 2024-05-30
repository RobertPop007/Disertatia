using Disertatie_backend.DTO;
using MongoDB.Bson;

namespace Disertatie_backend_Tests.DTOs
{
    public class AnimeModel
    {
        public ObjectId Id { get; set; }
        public int Mal_id { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Title_english { get; set; }
        public string? Title_japanese { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
