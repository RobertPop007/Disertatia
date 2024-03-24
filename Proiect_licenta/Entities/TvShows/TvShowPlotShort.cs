using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.TvShows
{
    public class TvShowPlotShort
    {
        [Key]
        public Guid TvShowPlotShortId { get; set; } = Guid.NewGuid();
        public string PlainText { get; set; }
        public string Html { get; set; }
    }
}
