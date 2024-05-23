using Disertatie_backend.Entities.User;
using Disertatie_backend_Tests.DTOs;

namespace Disertatie_backend_Tests.MockData
{
    public static class ReviewMockData
    {
        public static Review ValidReview(AppUser user, AnimeModel anime)
        {
            return new Review()
            {
                MainDescription = "Main description",
                ShortDescription = "Short description",
                Stars = 5,
                ItemId = anime.Id.ToString(),
                ReviewDate = DateTime.Now,
                User = user,
                UserId = user.Id,
                ReviewId = new Guid("FD35CF6D-5DA9-4767-81C3-BB0764C02BE8")
            };
        }
    }
}
