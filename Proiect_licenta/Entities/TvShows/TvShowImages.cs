using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.TvShows
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
        public List<TvShowItems> Items { get; set; }
        public string ErrorMessage { get; set; }
    }
}
