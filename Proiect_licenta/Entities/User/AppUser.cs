using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
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
        public Photo? ProfilePicture { get; set; }
        public IList<Guid>? FriendRequests { get; set; } = new List<Guid>();
        public IList<Friendships>? Friends { get; set; } = new List<Friendships>();
        public IList<Message>? MessagesSent { get; set; } = new List<Message>();
        public IList<Message>? MessagesReceived { get; set; } = new List<Message>();
        public IList<AppUserRole>? UserRoles { get; set; } = new List<AppUserRole>();

        public IList<string>? AppUserMovie { get; set; } = new List<string>();
        public IList<string>? AppUserTvShow { get; set; } = new List<string>();
        public IList<string>? AppUserAnime { get; set; } = new List<string>();
        public IList<string>? AppUserManga { get; set; } = new List<string>();
        public IList<string>? AppUserGame { get; set; } = new List<string>();

        public bool IsSubscribedToNewsletter { get; set; }
        public bool HasDarkMode { get; set; }

        public IList<string>? Reviews { get; set; } = new List<string>();
    }
}
