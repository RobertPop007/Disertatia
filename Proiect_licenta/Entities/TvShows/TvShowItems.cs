using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowItems
    {
        [Key]
        public Guid TvShowItemsId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
