using Disertatie_backend.Entities.Movies;
using MongoDB.Bson;
using System;

namespace Disertatie_backend.Entities.User
{
    public class AppUserMovieItem
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string MovieId { get; set; }
    }
}
