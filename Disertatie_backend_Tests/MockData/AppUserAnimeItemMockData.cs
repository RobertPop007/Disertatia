using Disertatie_backend.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disertatie_backend_Tests.MockData
{
    public static class AppUserAnimeItemMockData
    {
        public static AppUserAnimeItem UserAnime(AppUser user)
        {
            return new AppUserAnimeItem()
            {
                AnimeId = "6611a0727b2649a4fd4e6ec0",
                AppUserId = user.Id
            };
        }
    }
}
