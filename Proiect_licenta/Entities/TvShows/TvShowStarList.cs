using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowStarList
    {
        [Key]
        public Guid TvShowStarListId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
