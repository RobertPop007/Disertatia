using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using System;

namespace Disertatie_backend.Entities.User
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
