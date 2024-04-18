using MongoDB.Bson;

namespace Disertatie_backend.DTO.Manga
{
    public class MangaCard
    {
        public string Title { get; set; }
        public string Popularity { get; set; }
        public ObjectId Id { get; set; }
        public double? Score { get; set; }
        public string Image { get; set; }
        public string Year { get; set; }
    }
}
