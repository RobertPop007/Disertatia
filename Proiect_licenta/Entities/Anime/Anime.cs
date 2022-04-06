using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Anime
{
    public class Anime
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Pagination Pagination { get; set; }
        public IList<Datum> Data { get; set; }
    }
}
