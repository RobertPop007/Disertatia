using Disertatie_backend.Entities.Manga;

namespace Disertatie_backend.Entities
{
    public class AppUserMangaItem
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MangaId { get; set; }
        public DatumManga MangaItem { get; set; }
    }
}
