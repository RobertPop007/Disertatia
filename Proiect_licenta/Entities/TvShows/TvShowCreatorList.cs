using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowCreatorList
    {
        [Key]
        public Guid TvShowCreatorListId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
