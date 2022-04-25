using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowWikipedia
    {
        [Key]
        public Guid TvShowWikipediaId { get; set; } = Guid.NewGuid();
        public string ImDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Language { get; set; }
        public string TitleInLanguage { get; set; }
        public string Url { get; set; }
        public TvShowPlotShort PlotShort { get; set; }
        public TvShowPlotFull PlotFull { get; set; }
        public string ErrorMessage { get; set; }
    }
}
