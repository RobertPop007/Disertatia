using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowPlotFull
    {
        [Key]
        public Guid TvShowPlotFullId { get; set; } = Guid.NewGuid();
        public string PlainText { get; set; }
        public string Html { get; set; }
    }
}
