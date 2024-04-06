using MongoDB.Bson;

namespace Disertatie_backend.Helpers
{
    public class AddFriendParams : PaginationParams
    {
        public ObjectId UserId { get; set; }
        public string Predicate { get; set; }
    }
}
