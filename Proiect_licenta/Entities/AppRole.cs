using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Entities
{
    [CollectionName("Roles")]
    public class AppRole : MongoIdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
