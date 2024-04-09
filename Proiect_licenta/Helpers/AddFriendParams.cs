using MongoDB.Bson;
using System;

namespace Disertatie_backend.Helpers
{
    public class AddFriendParams : PaginationParams
    {
        public Guid UserId { get; set; }
        public string Predicate { get; set; }
    }
}
