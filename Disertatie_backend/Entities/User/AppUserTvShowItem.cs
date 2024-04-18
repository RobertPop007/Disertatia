using Disertatie_backend.Entities.TvShows;
using MongoDB.Bson;
using System;

namespace Disertatie_backend.Entities.User
{
    public class AppUserTvShowItem
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string TvShowId { get; set; }
    }
}
