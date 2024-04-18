using System;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Manga
{
    public class Manga
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public PaginationManga Pagination { get; set; }
        public IList<DatumManga> Data { get; set; }
    }
}
