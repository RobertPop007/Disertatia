using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowImages
    {
        [Key]
        public Guid TvShowImagesId { get; set; } = Guid.NewGuid();
        public string ImDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public List<TvShowItem> Items { get; set; }
        public string ErrorMessage { get; set; }
    }
}
