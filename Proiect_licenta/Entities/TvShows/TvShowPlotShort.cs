using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowPlotShort
    {
        [Key]
        public Guid TvShowPlotShortId { get; set; } = Guid.NewGuid();
        public string PlainText { get; set; }
        public string Html { get; set; }
    }
}
