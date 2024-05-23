using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.User
{
    public class AppUser : IdentityUser<Guid>
    {
#nullable enable
        public DateTime DateOfBirth { get; set; }
        public string? KnownAs { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? LastActive { get; set; } = DateTime.Now;
        public string? Gender { get; set; }
        public string? Introduction { get; set; }
        public string? Interests { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public Photo? Photos { get; set; }
        public IList<FriendRequest>? FriendRequests { get; set; } = new List<FriendRequest>();
        public IList<Friendships>? Friends { get; set; } = new List<Friendships>();
        public IList<Message>? MessagesSent { get; set; } = new List<Message>();
        public IList<Message>? MessagesReceived { get; set; } = new List<Message>();
        public IList<AppUserRole>? UserRoles { get; set; } = new List<AppUserRole>();

        public ICollection<AppUserMovieItem>? AppUserMovie { get; set; } = new List<AppUserMovieItem>();
        public ICollection<AppUserTvShowItem>? AppUserTvShow { get; set; } = new List<AppUserTvShowItem>();
        public ICollection<AppUserAnimeItem>? AppUserAnime { get; set; } = new List<AppUserAnimeItem>();
        public ICollection<AppUserMangaItem>? AppUserManga { get; set; } = new List<AppUserMangaItem>();
        public ICollection<AppUserGameItem>? AppUserGame { get; set; } = new List<AppUserGameItem>();
        public ICollection<AppUserBookItem>? AppUserBook { get; set; } = new List<AppUserBookItem>();

        public bool IsSubscribedToNewsletter { get; set; }
        public bool HasDarkMode { get; set; }

        public ICollection<Review>? Reviews { get; set; } = new List<Review>();
    }
}
