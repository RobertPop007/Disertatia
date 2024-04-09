using MongoDB.Bson;
using System;

namespace Disertatie_backend.Entities
{
    public class UserFriend
    {
        public AppUser AddedByUser { get; set; }
        public Guid AddedByUserId { get; set; }

        public AppUser AddedUser { get; set; }
        public Guid AddedUserId { get; set; }
    }
}
