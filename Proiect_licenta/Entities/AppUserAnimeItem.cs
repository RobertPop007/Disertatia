using Disertatie_backend.Entities.Anime;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Disertatie_backend.Entities
{
    public class AppUserAnimeItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int AnimeId { get; set; }
        public Datum AnimeItem { get; set; }
    }
}
