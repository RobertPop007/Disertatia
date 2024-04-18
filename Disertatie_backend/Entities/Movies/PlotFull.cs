using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Movies
{
    public class PlotFull
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PlainText { get; set; }
        public string Html { get; set; }
    }
}
