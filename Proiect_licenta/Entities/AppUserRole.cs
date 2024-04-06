using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;

namespace Disertatie_backend.Entities
{
    public class AppUserRole : IdentityUserRole<ObjectId>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
