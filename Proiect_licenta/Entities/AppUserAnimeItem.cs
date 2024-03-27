using Disertatie_backend.Entities.Anime;

namespace Disertatie_backend.Entities
{
    public class AppUserAnimeItem
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int AnimeId { get; set; }
        public Datum AnimeItem { get; set; }
    }
}
