using MongoDB.Bson;

namespace Disertatie_backend.Entities
{
    public class UserFriend
    {
        public AppUser AddedByUser { get; set; }
        public ObjectId AddedByUserId { get; set; }

        public AppUser AddedUser { get; set; }
        public ObjectId AddedUserId { get; set; }
    }
}
