using Disertatie_backend.Entities.Manga;
using MongoDB.Bson;

namespace Disertatie_backend.Entities.User
{
    public class AppUserMangaItem
    {
        public ObjectId AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MangaId { get; set; }
        public DatumManga MangaItem { get; set; }
    }
}
