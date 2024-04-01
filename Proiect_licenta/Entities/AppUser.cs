﻿using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Entities
{
    [CollectionName("Users")]
    public class AppUser : MongoIdentityUser<int>
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
        public ICollection<UserFriend> AddedByUsers { get; set; }
        public ICollection<UserFriend> AddedUsers { get; set; }
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

        public IList<AppUserMovieItem> AppUserMovie { get; set; }
        public IList<AppUserTvShowItem> AppUserTvShow { get; set; }
        public IList<AppUserAnimeItem> AppUserAnime { get; set; }
        public IList<AppUserMangaItem> AppUserManga { get; set; }
        public IList<AppUserGameItem> AppUserGame { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public bool HasDarkMode { get; set; }
    }
}
