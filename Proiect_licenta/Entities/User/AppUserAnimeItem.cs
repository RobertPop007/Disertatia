using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Disertatie_backend.Entities.User
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
