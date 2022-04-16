using System;

namespace Proiect_licenta.Entities.Manga
{
    public class ToManga
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
