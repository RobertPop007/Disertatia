using System;
using System.Collections.Generic;

namespace Proiect_licenta.Entities.Anime
{
    public class Anime
    {
        public Guid AnimeId { get; set; } = Guid.NewGuid();
        public Pagination Pagination { get; set; }
        public IList<Datum> Data { get; set; }
    }
}
