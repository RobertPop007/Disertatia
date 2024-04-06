using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;
using System.Collections.Generic;

namespace Disertatie_backend.Entities
{
    [CollectionName("Roles")]
    public class AppRole : MongoIdentityRole<ObjectId>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
