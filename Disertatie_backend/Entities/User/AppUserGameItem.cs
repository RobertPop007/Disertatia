using Disertatie_backend.Entities.Games.Game;
using MongoDB.Bson;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disertatie_backend.Entities.User
{
    public class AppUserGameItem
    {
        public Guid AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

        public string GameId { get; set; }
    }
}
