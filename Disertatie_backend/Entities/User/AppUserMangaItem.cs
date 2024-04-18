using Disertatie_backend.Entities.Manga;
using MongoDB.Bson;
using System;

namespace Disertatie_backend.Entities.User
{
    public class AppUserMangaItem
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string MangaId { get; set; }
    }
}
