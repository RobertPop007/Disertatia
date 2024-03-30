using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.EntityFrameworkCore;
using System;

namespace Disertatie_backend.DTO.Identity
{
    [Collection("Users")]
    public class ApplicationUsers : MongoIdentityUser<Guid>
    {
    }
}
