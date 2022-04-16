using System;
using System.Collections.Generic;

namespace Proiect_licenta.Entities.Manga
{
    public class Manga
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public PaginationManga Pagination { get; set; }
        public IList<DatumManga> Data { get; set; }
    }
}
