using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Entities
{
    [CollectionName("Users")]
    public class AppUser : MongoIdentityUser<ObjectId>
    {
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Photo ProfilePicture { get; set; }
        public ICollection<UserFriend> AddedByUsers { get; set; } = new HashSet<UserFriend>();
        public ICollection<UserFriend> AddedUsers { get; set; } = new HashSet<UserFriend>();
        public ICollection<Message> MessagesSent { get; set; } = new HashSet<Message>();
        public ICollection<Message> MessagesReceived { get; set; } = new HashSet<Message>();
        public ICollection<AppUserRole> UserRoles { get; set; } = new HashSet<AppUserRole>();

        public ICollection<AppUserMovieItem> AppUserMovie { get; set; } = new HashSet<AppUserMovieItem>();
        public ICollection<AppUserTvShowItem> AppUserTvShow { get; set; } = new HashSet<AppUserTvShowItem>();
        public ICollection<ObjectId> AppUserAnime { get; set; } = new HashSet<ObjectId>();
        public ICollection<AppUserMangaItem> AppUserManga { get; set; } = new HashSet<AppUserMangaItem>();
        public ICollection<AppUserGameItem> AppUserGame { get; set; } = new HashSet<AppUserGameItem>();

        public bool IsSubscribedToNewsletter { get; set; }
        public bool HasDarkMode { get; set; }
    }
}
