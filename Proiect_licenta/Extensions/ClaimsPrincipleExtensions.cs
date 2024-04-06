using MongoDB.Bson;
using System.Security.Claims;

namespace Disertatie_backend.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static ObjectId GetUserId(this ClaimsPrincipal user)
        {
            return ObjectId.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
