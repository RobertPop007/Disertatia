using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Anime
{
    public class Anime
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Pagination Pagination { get; set; }
        public IList<Datum> Data { get; set; }
    }
}
