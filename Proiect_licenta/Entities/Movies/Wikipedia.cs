using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Movies
{
    public class Wikipedia
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ImDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Language { get; set; }
        public string TitleInLanguage { get; set; }
        public string Url { get; set; }
        public PlotShort PlotShort { get; set; }
        public PlotFull PlotFull { get; set; }
        public string ErrorMessage { get; set; }
    }
}
