using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowSimilar
    {
        [Key]
        public Guid TvShowSimilarId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImDbRating { get; set; }
    }
}
