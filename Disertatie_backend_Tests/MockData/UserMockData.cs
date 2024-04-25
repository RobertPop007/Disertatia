using Disertatie_backend.Entities.User;

namespace Disertatie_backend_Tests.MockData
{
    public static class UserMockData
    {
        public static AppUser ValidUser()
        {
            return new AppUser()
            {
                AccessFailedCount = 0,
                AppUserAnime = new List<AppUserAnimeItem>(),
                AppUserGame = new List<AppUserGameItem>(),
                AppUserManga = new List<AppUserMangaItem>(),
                AppUserMovie = new List<AppUserMovieItem>(),
                AppUserTvShow = new List<AppUserTvShowItem>(),
                City = "Random City",
                ConcurrencyStamp = "random",
                Country = "Random Country",
                Created = DateTime.Now,
                DateOfBirth = DateTime.Now,
                Email = "Random Email",
                EmailConfirmed = false,
                FriendRequests = new List<Guid>(),
                Friends = new List<Friendships>(),
                Gender = "Random Gender",
                HasDarkMode = true,
                Id = Guid.NewGuid(),
                Interests = "Random Interests",
                Introduction = "Random Introduction",
                IsSubscribedToNewsletter = true,
                KnownAs = "Random AKA",
                LastActive = DateTime.Now,
                LockoutEnabled = true,
                LockoutEnd = DateTime.Now,
                MessagesReceived = new List<Message>(),
                MessagesSent = new List<Message>(),
                NormalizedEmail = "Random Normalized Email",
                NormalizedUserName = "Random Normalized Username",
                PasswordHash = "Random Hash",
                PhoneNumber = "Random Phone",
                PhoneNumberConfirmed = false,
                Photos = new Photo(),
                Reviews = new List<Review>(),
                SecurityStamp = "Random Security Stamp",
                TwoFactorEnabled = true,
                UserName = "Random Username",
                UserRoles = new List<AppUserRole>()
            };
        }
    }
}
