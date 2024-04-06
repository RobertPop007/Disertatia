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
        public ObjectId AppUserId { get; set; }

        public ObjectId AnimeId { get; set; }
    }
}
