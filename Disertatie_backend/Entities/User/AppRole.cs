using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.User
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
