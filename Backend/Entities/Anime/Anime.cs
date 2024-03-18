using System;
using System.Collections.Generic;

namespace Backend.Entities.Anime;

public class Anime
{
    public Guid AnimeId { get; set; } = Guid.NewGuid();
    public Pagination Pagination { get; set; }
    public IList<Datum> Data { get; set; }
}
