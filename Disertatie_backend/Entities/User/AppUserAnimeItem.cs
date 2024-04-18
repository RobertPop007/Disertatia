using MongoDB.Bson;
using System;
using Disertatie_backend.Entities.Anime;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disertatie_backend.Entities.User
{
    public class AppUserAnimeItem
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string AnimeId { get; set; }
    }
}
