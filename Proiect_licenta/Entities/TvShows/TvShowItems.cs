using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowItems
    {
        [Key]
        public Guid TvShowItemsId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
