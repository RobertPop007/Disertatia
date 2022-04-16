using System;

namespace Proiect_licenta.Entities.Manga
{
    public class PaginationManga
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Last_visible_page { get; set; }
        public bool Has_next_page { get; set; }
    }
}
