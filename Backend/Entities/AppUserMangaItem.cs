using Proiect_licenta.Entities.Manga;

namespace Proiect_licenta.Entities
{
    public class AppUserMangaItem
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MangaId { get; set; }
        public DatumManga MangaItem { get; set; }
    }
}
