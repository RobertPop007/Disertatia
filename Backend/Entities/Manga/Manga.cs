using System;
using System.Collections.Generic;

namespace Backend.Entities.Manga;

public class Manga
{
    public Guid MangaId { get; set; } = Guid.NewGuid();
    public PaginationManga Pagination { get; set; }
    public IList<DatumManga> Data { get; set; }
}
