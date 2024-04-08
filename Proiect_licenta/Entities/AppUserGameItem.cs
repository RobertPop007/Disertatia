using MongoDB.Bson;

namespace Disertatie_backend.Entities
{
    public class AppUserGameItem
    {
        public ObjectId AppUserId { get; set; }
        public int GameId { get; set; }
    }
}
