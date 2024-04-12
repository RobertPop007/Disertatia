using MongoDB.Bson;

namespace Disertatie_backend.Entities.User
{
    public class AppUserGameItem
    {
        public ObjectId AppUserId { get; set; }
        public int GameId { get; set; }
    }
}
